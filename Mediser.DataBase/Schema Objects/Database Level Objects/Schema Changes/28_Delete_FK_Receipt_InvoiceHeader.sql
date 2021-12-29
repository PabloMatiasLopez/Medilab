ALTER TABLE [dbo].[ReceiptInvoice] DROP CONSTRAINT [FK_ReceiptInvoice_InvoiceHeader]
GO
ALTER TABLE [dbo].[ReceiptInvoice] ADD VoucherType INT null
GO

--Update Voucher Type

select ri.ReceiptInvoiceId from ReceiptInvoice ri
join InvoiceHeader i on ri.InvoiceId = i.InvoiceHeaderId
where i.InvoiceType = 1

select ri.ReceiptInvoiceId from ReceiptInvoice ri
join InvoiceHeader i on ri.InvoiceId = i.InvoiceHeaderId
where i.InvoiceType = 2

/*
update ReceiptInvoice set VoucherType = 1 where ReceiptInvoiceId in (
select ri.ReceiptInvoiceId from ReceiptInvoice ri
join InvoiceHeader i on ri.InvoiceId = i.InvoiceHeaderId
where i.InvoiceType = 1)

update ReceiptInvoice set VoucherType = 1 where ReceiptInvoiceId in (
select ri.ReceiptInvoiceId from ReceiptInvoice ri
join InvoiceHeader i on ri.InvoiceId = i.InvoiceHeaderId
where i.InvoiceType = 2)
*/


--Set vouchertype to notnull
ALTER TABLE [dbo].[ReceiptInvoice] 
ALTER COLUMN VoucherType INT NOT NULL
