using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.Receipt
{
    public interface IPayable
    {
        void UpdatePaidAmmount(MedilabEntities context, Guid receiptId);
        void RegisterPayment(MedilabEntities context, Guid receiptId);
    }
}
