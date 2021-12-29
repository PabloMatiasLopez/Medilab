using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Medilab.BusinessObjects.Configuration
{
    public class NextDebitNoteNumber
    {
        #region Properties
        public int Id { private set; get; }
        public NoteType DebitNoteType { set; get; }
        public int MasterNumber { set; get; }
        public int DebitNoteNumber { set; get; }
        public byte[] LastUpdated { get; set; }
        #endregion

        #region Methods
        public void SetNextNumber(NoteType debitNoteType)
        {
            using (var context = new MedilabEntities())
            {
                var type = (int)debitNoteType;
                var nextNumber =
                    (from n in context.NextDebitNoteNumber where n.DebitNoteType == type select n).FirstOrDefault();
                if (nextNumber == null)
                {
                    var newCreditNoteNumber = new DataAccess.NextDebitNoteNumber
                    {
                        MasterNumber = MasterNumber,
                        DebitNoteNumber = DebitNoteNumber,
                        DebitNoteType = (int)debitNoteType
                    };
                    context.AddToNextDebitNoteNumber(newCreditNoteNumber);
                }
                else
                {
                    if (Tools.IsRecordChanged(nextNumber.LastUpdated, LastUpdated))
                    {
                        throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                    }
                    nextNumber.MasterNumber = MasterNumber;
                    nextNumber.DebitNoteNumber = DebitNoteNumber;
                }
                context.SaveChanges();
            }
        }
        public NextDebitNoteNumber GetNextNumber(NoteType debitNoteType)
        {
            using (var context = new MedilabEntities())
            {
                var type = (int)debitNoteType;
                var nextNumber =
                    (from n in context.NextDebitNoteNumber where n.DebitNoteType == type select n).FirstOrDefault();
                if (nextNumber != null)
                {
                    Id = nextNumber.DebitNoteNumberID;
                    DebitNoteType =
                        (NoteType)
                        Enum.Parse(typeof(NoteType),
                                   nextNumber.DebitNoteType.ToString(CultureInfo.InvariantCulture));
                    MasterNumber = nextNumber.MasterNumber;
                    DebitNoteNumber = nextNumber.DebitNoteNumber;
                    LastUpdated = nextNumber.LastUpdated;
                    return this;
                }

                DebitNoteType = debitNoteType;
                MasterNumber = 0;
                DebitNoteNumber = 0;
                return this;
            }
        }
        public string GetNextNumberDisplay(NoteType debitNoteType)
        {
            GetNextNumber(debitNoteType);
            return string.Format("{0}-{1}", MasterNumber.ToString("0000"), DebitNoteNumber.ToString("00000000"));
        }
        public void AddCreditNoteNumber(NoteType debitNoteType)
        {
            GetNextNumber(debitNoteType);
            DebitNoteNumber++;
            SetNextNumber(debitNoteType);
        }
        #endregion
    }
}
