using System;
using System.Collections.Generic;
using System.Drawing;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.UserInterface.PrintUtilities
{
    public class InvoiceHeader
    {

        #region Variables

        private PrinterMetaData _invoiceDate;
        private PrinterMetaData _clientName ;
        private PrinterMetaData _clientAddress;
        private PrinterMetaData _iVaCondition;
        private PrinterMetaData _sellCondition;
        private PrinterMetaData _clientCuit;
        private PrinterMetaData _clientNumber;
        private PrinterMetaData _caeData;
        private PrinterMetaData _invoiceNumber;
        private PrinterMetaData _invoiceType;

        private PrinterMetaData _invoiceDateLabel;
        private PrinterMetaData _clientNameLabel;
        private PrinterMetaData _clientAddressLabel;
        private PrinterMetaData _iVaConditionLabel;
        private PrinterMetaData _sellConditionLabel;
        private PrinterMetaData _clientCuitLabel;
        private PrinterMetaData _clientNumberLabel;
        
        private List<PrinterMetaData> headerElements = new List<PrinterMetaData>();
        
        
        #endregion

        public List<PrinterMetaData> FillInvoiceHeader(InvoiceHeaderDto headerDto)
        {

            

            #region Static Values
            _invoiceType.Data = headerDto.InvoiceType.ToString();
            _invoiceType.isBold = true;
            _invoiceType.maxLineLength = 100;
            _invoiceType.printFont = new Font("Calibri", 14);
            _invoiceType.xPos = _invoiceDate.UnitConvertion(14.35);
            _invoiceType.yPos = _invoiceDate.UnitConvertion(1.8);
            //Date Label
            _invoiceDateLabel.Data = "FECHA: ";
            _invoiceDateLabel.isBold = true;
            _invoiceDateLabel.maxLineLength = 100;
            _invoiceDateLabel.printFont = new Font("Calibri", 14);
            _invoiceDateLabel.xPos = _invoiceDate.UnitConvertion(14.35);
            _invoiceDateLabel.yPos = _invoiceDate.UnitConvertion(1.8);
            //Date
            _invoiceDate.isBold = true;
            _invoiceDate.maxLineLength = 100;
            _invoiceDate.printFont = new Font("Calibri",14);
            //PLACE THE POSITION in CENTIMETERS
            _invoiceDate.xPos = _invoiceDate.UnitConvertion(16.00);
            _invoiceDate.yPos = _invoiceDate.UnitConvertion(1.8);


            //ClientName Label
            _clientNameLabel.Data="Sr/es: ";
            _clientNameLabel.isBold = true;
            _clientNameLabel.maxLineLength = 100;
            _clientNameLabel.printFont = new Font("Calibri", 12);
            _clientNameLabel.xPos = _clientName.UnitConvertion(1.1); //-0.9
            _clientNameLabel.yPos = _clientName.UnitConvertion(5.1); //-0.4
            //ClientName
            _clientName.isBold = false;
            _clientName.maxLineLength = 100;
            _clientName.printFont = new Font("Calibri", 14);
            _clientName.xPos = _clientName.UnitConvertion(2.3);
            _clientName.yPos = _clientName.UnitConvertion(5.0);


            //ClientAddressLabel
            _clientAddressLabel.Data = "Domicilio: ";
            _clientAddressLabel.isBold = false;
            _clientAddressLabel.maxLineLength = 100;
            _clientAddressLabel.printFont = new Font("Calibri", 12);
            _clientAddressLabel.xPos = _clientAddress.UnitConvertion(1.1);
            _clientAddressLabel.yPos = _clientAddress.UnitConvertion(5.8);
            //ClientAddress
            _clientAddress.isBold = true;
            _clientAddress.maxLineLength = 100;
            _clientAddress.printFont = new Font("Calibri", 12);
            _clientAddress.xPos = _clientAddress.UnitConvertion(3.1);
            _clientAddress.yPos = _clientAddress.UnitConvertion(5.8);

            //iVAConditionLabel
            _iVaConditionLabel.Data = "I.V.A.: ";
            _iVaConditionLabel.isBold = false;
            _iVaConditionLabel.maxLineLength = 100;
            _iVaConditionLabel.printFont = new Font("Calibri", 12);
            _iVaConditionLabel.xPos = _iVaCondition.UnitConvertion(1.1);
            _iVaConditionLabel.yPos = _iVaCondition.UnitConvertion(6.5);
            //iVACondition
            _iVaCondition.isBold = true;
            _iVaCondition.maxLineLength = 100;
            _iVaCondition.printFont = new Font("Calibri", 12);
            _iVaCondition.xPos = _iVaCondition.UnitConvertion(2.4);
            _iVaCondition.yPos = _iVaCondition.UnitConvertion(6.5);

            //sellConditionLabel
            _sellConditionLabel.Data = "Cond. de Venta: ";
            _sellConditionLabel.isBold = false;
            _sellConditionLabel.maxLineLength = 100;
            _sellConditionLabel.printFont = new Font("Calibri", 12);
            _sellConditionLabel.xPos = _sellCondition.UnitConvertion(1.1);
            _sellConditionLabel.yPos = _sellCondition.UnitConvertion(7.2);
            //sellCondition
            _sellCondition.isBold = true;
            _sellCondition.maxLineLength = 100;
            _sellCondition.printFont = new Font("Calibri", 12);
            _sellCondition.xPos = _sellCondition.UnitConvertion(4.3);
            _sellCondition.yPos = _sellCondition.UnitConvertion(7.2);

            //clientCUITLabel
            _clientCuitLabel.Data = "C.U.I.T.: ";
            _clientCuitLabel.isBold = false;
            _clientCuitLabel.maxLineLength = 100;
            _clientCuitLabel.printFont = new Font("Calibri", 12);
            _clientCuitLabel.xPos = _sellCondition.UnitConvertion(13.1);
            _clientCuitLabel.yPos = _sellCondition.UnitConvertion(6.5);
            //clientCUIT
            _clientCuit.isBold = true;
            _clientCuit.maxLineLength = 100;
            _clientCuit.printFont = new Font("Calibri", 12);
            _clientCuit.xPos = _sellCondition.UnitConvertion(14.8);
            _clientCuit.yPos = _sellCondition.UnitConvertion(6.5);

            //clientNumberLabel
            _clientNumberLabel.Data = "Client N°: ";
            _clientNumberLabel.isBold = false;
            _clientNumberLabel.maxLineLength = 100;
            _clientNumberLabel.printFont = new Font("Calibri", 12);
            _clientNumberLabel.xPos = _sellCondition.UnitConvertion(13.1);
            _clientNumberLabel.yPos = _sellCondition.UnitConvertion(7.2);
            
            //clientNumber
            _clientNumber.isBold = true;
            _clientNumber.maxLineLength = 100;
            _clientNumber.printFont = new Font("Calibri", 12);
            _clientNumber.xPos = _sellCondition.UnitConvertion(14.0);
            _clientNumber.yPos = _sellCondition.UnitConvertion(26.3);

           //Cae
            _caeData.isBold = false;
            _caeData.maxLineLength = 100;
            _caeData.printFont = new Font("Calibri", 9);
            _caeData.xPos = _sellCondition.UnitConvertion(16.0);
            _caeData.yPos = _sellCondition.UnitConvertion(28.0);
             #endregion

            _invoiceDate.Data = headerDto.Date.ToShortDateString();
            _clientName.Data = headerDto.ClientName.ToUpper();

           
            _clientAddress.Data = headerDto.ClientAddress.ToUpper();
            _iVaCondition.Data = headerDto.IVACondition.ToUpper();
            _sellCondition.Data = headerDto.SellCondition;
            _clientCuit.Data = headerDto.ClientCUIT;
            _clientNumber.Data = headerDto.ClientNumber;
            _caeData.Data = string.Concat("C.A.E N°: ", headerDto.CAE);

            //It's only printed if the invoice status is PRINTED (DUPLICATE INVOICE)
            //if ((int)headerDto.Status > 3)
            //{

            //    _invoiceType.Data = headerDto.InvoiceType.ToString();
            //    _invoiceType.isBold = true;
            //    _invoiceType.maxLineLength = 100;
            //    _invoiceType.printFont = new Font("Times New Roman", 28);
            //    _invoiceType.xPos = _sellCondition.UnitConvertion(10.3);
            //    _invoiceType.yPos = _sellCondition.UnitConvertion(1.5);

            //    _invoiceNumber.Data = string.Concat("DUPLICADO:",headerDto.InvoiceNumber);   
            //    _invoiceNumber.isBold = true;
            //    _invoiceNumber.maxLineLength = 100;
            //    _invoiceNumber.printFont = new Font("Calibri", 16);
            //    _invoiceNumber.xPos = _sellCondition.UnitConvertion(16.0);
            //    _invoiceNumber.yPos = _sellCondition.UnitConvertion(1.5);
               
            //    headerElements.Add(_invoiceType);
            //    headerElements.Add(_invoiceNumber);
            //}

            headerElements.Add(_invoiceType);
            headerElements.Add(_invoiceDateLabel);
            headerElements.Add(_invoiceDate);
            headerElements.Add(_clientNameLabel);
            headerElements.Add(_clientName);
            headerElements.Add(_clientAddressLabel);
            headerElements.Add(_clientAddress);
            headerElements.Add(_iVaConditionLabel);
            headerElements.Add(_iVaCondition);
            headerElements.Add(_sellConditionLabel);
            headerElements.Add(_sellCondition);
            headerElements.Add(_clientCuitLabel);
            headerElements.Add(_clientCuit);
            headerElements.Add(_clientNumberLabel);
            headerElements.Add(_clientNumber);
            headerElements.Add(_caeData);
            return headerElements;

        }
    }
}
