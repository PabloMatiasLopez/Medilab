using System;

namespace Medilab.BusinessObjects.Patient
{
    public class PatientListItemDto
    {
        #region Properties
        public Guid Id { get; set; }
        public string DocumentType { set; get; }
        public string DocumentNumber { set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string Photo { set; get; }
        #endregion
    }
}
