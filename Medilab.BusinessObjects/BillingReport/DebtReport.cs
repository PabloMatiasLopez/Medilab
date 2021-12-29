using System;
using System.Collections.Generic;
using Medilab.BusinessObjects.CAE;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System.Linq;

namespace Medilab.BusinessObjects.BillingReport
{
    public static class DebtReport
    {
        public static DebtReportResultDto DebtByClientReport(DebtReportCriteriaDto criteria)
        {
            var reportItems = new List<DebtByClientItemDto>();
            using (var context = new MedilabEntities())
            {
                reportItems.AddRange(GetInvoicesByClient(context, criteria));
                if (!criteria.OnlyPending)
                {
                    reportItems.AddRange(GetReceiptsByClient(context, criteria));
                }
                reportItems.AddRange(GetDebitNotesByClient(context, criteria));

                var result = new DebtReportResultDto
                {
                    Items = reportItems.OrderBy(i => i.Date).ToList(),
                    Total = GetDebtTotal(context, criteria)
                };
                return result;
            }
        }

        private static IEnumerable<DebtByClientItemDto> GetInvoicesByClient(MedilabEntities context, DebtReportCriteriaDto criteria)
        {
            var invoices = (from h in context.InvoiceHeader select h);
            if (criteria.SearchByClientNumber)
            {
                invoices = invoices.Where(i => i.Client.ClientNumber == criteria.ClientNumber);
            }
            else
            {
                invoices = invoices.Where(i => i.ClientId == criteria.ClientId);
            }
            if (criteria.OnlyPending)
            {
                const int paidStatus = (int)InvoiceStatus.Pagada;
                invoices = invoices.Where(h => h.Status != paidStatus);
                return GetInvoiceDtos(invoices);
            }
            invoices = invoices.Where(h => h.Date >= criteria.DateFrom.Date && h.Date <= criteria.DateTo);
            return GetInvoiceDtos(invoices);
        }

        private static IEnumerable<DebtByClientItemDto> GetReceiptsByClient(MedilabEntities context, DebtReportCriteriaDto criteria)
        {
            var receipts = (from h in context.Receipt select h);
            if (criteria.SearchByClientNumber)
            {
                receipts = receipts.Where(r => r.Client.ClientNumber == criteria.ClientNumber);
            }
            else
            {
                receipts = receipts.Where(r => r.ClientId == criteria.ClientId);
            }
            receipts = receipts.Where(h => h.Date >= criteria.DateFrom.Date && h.Date <= criteria.DateTo);
            return GetReceiptDtos(context, receipts);
        }

        private static IEnumerable<DebtByClientItemDto> GetCreditNotesByClient(MedilabEntities context, DebtReportCriteriaDto criteria)
        {
            var creditNotes = (from cn in context.CreditNote where cn.ClientId == criteria.ClientId select cn);
            if (criteria.SearchByClientNumber)
            {
                creditNotes = creditNotes.Where(cn => cn.Client.ClientNumber == criteria.ClientNumber);
            }
            else
            {
                creditNotes = creditNotes.Where(cn => cn.ClientId == criteria.ClientId);
            }
            if (criteria.OnlyPending)
            {
                const int newState = (int)CrediDebitNoteState.Nueva;
                creditNotes = creditNotes.Where(cn => cn.State == newState);
                return GetCreditNoteDtos(creditNotes);
            }
            creditNotes = creditNotes.Where(h => h.CreationDate >= criteria.DateFrom.Date && h.CreationDate <= criteria.DateTo);
            return GetCreditNoteDtos(creditNotes);
        }

        private static IEnumerable<DebtByClientItemDto> GetDebitNotesByClient(MedilabEntities context, DebtReportCriteriaDto criteria)
        {
            var debitNotes = (from dn in context.DebitNote select dn);
            if (criteria.SearchByClientNumber)
            {
                debitNotes = debitNotes.Where(dn => dn.Client.ClientNumber == criteria.ClientNumber);
            }
            else
            {
                debitNotes = debitNotes.Where(dn => dn.Client.ClientId == criteria.ClientId);
            }
            if (criteria.OnlyPending)
            {
                const int newState = (int)CrediDebitNoteState.Nueva;
                debitNotes = debitNotes.Where(cn => cn.State == newState);
                return GetDebitNoteDtos(debitNotes);
            }
            debitNotes = debitNotes.Where(h => h.CreationDate >= criteria.DateFrom.Date && h.CreationDate <= criteria.DateTo);
            return GetDebitNoteDtos(debitNotes);
        }

        private static IEnumerable<DebtByClientItemDto> GetInvoiceDtos(IEnumerable<InvoiceHeader> invoices)
        {
            var list = new List<DebtByClientItemDto>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (InvoiceHeader invoice in invoices)
            {
                list.Add(new DebtByClientItemDto
                {
                    Date = invoice.Date,
                    Remainder = invoice.InvoiceRemainder.ToString("C2"),
                    Total = invoice.Total,
                    Type = string.Format("Factura {0}", ((InvoiceType)invoice.InvoiceType)),
                    DocumentNumber = string.Format("{0}-{1}", invoice.SalePoint.ToString("0000"), invoice.InvoiceNumber.ToString("00000000")),
                    Notes = string.Format("Estado: {0}", invoice.Status == (int)InvoiceStatus.Pagada ? "Cancelada":"Pendiente")
                });
            }
            return list;
        }

        private static IEnumerable<DebtByClientItemDto> GetReceiptDtos(MedilabEntities context, IEnumerable<DataAccess.Receipt> receipts)
        {
            var list = new List<DebtByClientItemDto>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (DataAccess.Receipt receipt in receipts)
            {
                list.Add(new DebtByClientItemDto
                {
                    Date = receipt.Date,
                    Total = receipt.Total * (-1),
                    Type = "Recibo",
                    DocumentNumber = receipt.ReceiptNumber,
                    Notes = GetInvoicesData(context, receipt.ReceiptInvoice.ToList())
                });
            }
            return list;
        }

        private static string GetInvoicesData(MedilabEntities context, List<ReceiptInvoice> receiptInvoices)
        {
            string invoicesData = string.Empty;
            ReceiptInvoice lastElement = receiptInvoices.Last();
            foreach (ReceiptInvoice receiptInvoice in receiptInvoices)
            {
                if (string.IsNullOrEmpty(invoicesData))
                {
                    invoicesData = string.Format("Documentos incluidos:{0}", Environment.NewLine);
                }
                string voucherType = Enums.GetDocumentName((Enums.TipoComprobante)receiptInvoice.VoucherType); 
                if (!receiptInvoice.Equals(lastElement))
                {
                    invoicesData += string.Format("  {0} Nº {1}{2}", voucherType,
                        GetDocumentNumber(context, receiptInvoice), Environment.NewLine);
                }
                else
                {
                    invoicesData += string.Format("  {0} Nº {1}", voucherType,
                        GetDocumentNumber(context, receiptInvoice));
                }
            }
            return invoicesData;
        }

        private static string GetDocumentNumber(MedilabEntities context, ReceiptInvoice receiptInvoice)
        {
            if (receiptInvoice.VoucherType == (int) Enums.TipoComprobante.FACTURAS_A ||
                receiptInvoice.VoucherType == (int) Enums.TipoComprobante.FACTURAS_B)
            {
                return Invoice.InvoiceHeader.GetInvoiceNumber(context, receiptInvoice.InvoiceId);
            }
            return DebitCreditNote.DebitNote.GetDebitNoteNumber(context, receiptInvoice.InvoiceId);
        }

        private static IEnumerable<DebtByClientItemDto> GetCreditNoteDtos(IEnumerable<CreditNote> creditNotes)
        {
            var list = new List<DebtByClientItemDto>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (CreditNote creditNote in creditNotes)
            {
                list.Add(new DebtByClientItemDto
                {
                    Date = creditNote.CreationDate,
                    Total = creditNote.Import * (-1),
                    Type = "Nota de Crédito",
                    DocumentNumber = string.Format("{0}-{1}", creditNote.SalePoint.ToString("0000"), creditNote.CreditNoteNumber.ToString("00000000"))
                });
            }
            return list;
        }

        private static IEnumerable<DebtByClientItemDto> GetDebitNoteDtos(IEnumerable<DebitNote> debitNotes)
        {
            var list = new List<DebtByClientItemDto>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (DebitNote debitNote in debitNotes)
            {
                list.Add(new DebtByClientItemDto
                {
                    Date = debitNote.CreationDate,
                    Total = debitNote.Import,
                    Type = "Nota de Débito",
                    DocumentNumber = string.Format("{0}-{1}", debitNote.SalePoint.ToString("0000"), debitNote.DebitNoteNumber.ToString("00000000")),
                    Notes = string.Format("Estado: {0}", debitNote.State == (int)CrediDebitNoteState.Usada ? "Cancelada":"Pendiente")
                });
            }
            return list;
        }

        private static double GetDebtTotal(MedilabEntities context, DebtReportCriteriaDto criteria)
        {
            var invoices = (from h in context.InvoiceHeader select h);
            const int pendingState = (int) CrediDebitNoteState.Nueva;
            var debitNotes = (from dn in context.DebitNote where dn.State == pendingState select dn );
            if (criteria.SearchByClientNumber)
            {
                invoices = invoices.Where(i => i.Client.ClientNumber == criteria.ClientNumber);
                debitNotes = debitNotes.Where(dn => dn.Client.ClientNumber == criteria.ClientNumber);
            }
            else
            {
                invoices = invoices.Where(i => i.ClientId == criteria.ClientId);
                debitNotes = debitNotes.Where(dn => dn.Client.ClientId == criteria.ClientId);
            }
            if (!criteria.OnlyPending)
            {
                invoices = invoices.Where(h => h.Date >= criteria.DateFrom.Date && h.Date <= criteria.DateTo);
                debitNotes = debitNotes.Where(h => h.CreationDate >= criteria.DateFrom.Date && h.CreationDate <= criteria.DateTo);
            }
            double totalDebt = invoices.Select(ih => (double?)ih.InvoiceRemainder).Sum() ?? 0;
            totalDebt += debitNotes.Select(dn => (double?)dn.Import).Sum() ?? 0;
            return totalDebt;
        }
    }
}
