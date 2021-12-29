using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Medilab.BusinessObjects.Configuration
{
    public class NextCreditNoteNumber
    {
        #region Properties
        public int Id { private set; get; }
        public NoteType CreditNoteType { set; get; }
        public int MasterNumber { set; get; }
        public int CreditNoteNumber { set; get; }
        public byte[] LastUpdated { get; set; }
        #endregion

        #region Methods
        public void SetNextNumber(NoteType creditNoteType)
        {
            using (var context = new MedilabEntities())
            {
                var type = (int)creditNoteType;
                var nextNumber =
                    (from n in context.NextCreditNoteNumber where n.CreditNoteType == type select n).FirstOrDefault();
                if (nextNumber == null)
                {
                    var newCreditNoteNumber = new DataAccess.NextCreditNoteNumber
                    {
                        MasterNumber = MasterNumber,
                        CreditNoteNumber = CreditNoteNumber,
                        CreditNoteType = (int)creditNoteType
                    };
                    context.AddToNextCreditNoteNumber(newCreditNoteNumber);
                }
                else
                {
                    if (Tools.IsRecordChanged(nextNumber.LastUpdated, LastUpdated))
                    {
                        throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                    }
                    nextNumber.MasterNumber = MasterNumber;
                    nextNumber.CreditNoteNumber = CreditNoteNumber;
                }
                context.SaveChanges();
            }
        }
        public NextCreditNoteNumber GetNextNumber(NoteType creditNoteType)
        {
            using (var context = new MedilabEntities())
            {
                var type = (int)creditNoteType;
                var nextNumber =
                    (from n in context.NextCreditNoteNumber where n.CreditNoteType == type select n).FirstOrDefault();
                if (nextNumber != null)
                {
                    Id = nextNumber.CreditNoteNumberID;
                    CreditNoteType =
                        (NoteType)
                        Enum.Parse(typeof(NoteType),
                                   nextNumber.CreditNoteType.ToString(CultureInfo.InvariantCulture));
                    MasterNumber = nextNumber.MasterNumber;
                    CreditNoteNumber = nextNumber.CreditNoteNumber;
                    LastUpdated = nextNumber.LastUpdated;
                    return this;
                }

                CreditNoteType = creditNoteType;
                MasterNumber = 0;
                CreditNoteNumber = 0;
                return this;
            }
        }
        public string GetNextNumberDisplay(NoteType noteType)
        {
            GetNextNumber(noteType);
            return string.Format("{0}-{1}", MasterNumber.ToString("0000"), CreditNoteNumber.ToString("00000000"));
        }
        public void AddCreditNoteNumber(NoteType noteType)
        {
            GetNextNumber(noteType);
            CreditNoteNumber++;
            SetNextNumber(noteType);
        }
        #endregion
    }
}
