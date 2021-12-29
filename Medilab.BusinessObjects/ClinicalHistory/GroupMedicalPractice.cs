using System;
using System.Linq;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class GroupMedicalPractice
    {
        #region Properties
        public Guid Id { private set; get; }
        public Guid GroupId { set; get; }
        public Guid MedicalPracticeId { set; get; }
        #endregion

        #region Methods
        public GroupMedicalPractice()
        {
        }

        public GroupMedicalPractice(Guid id)
        {
            Id = id;
        }

        public GroupMedicalPractice Save()
        {
            using (var context = new MedilabEntities())
            {
                Save(context);
                context.SaveChanges();
                return this;
            }
        }

        internal void Save(MedilabEntities context)
        {
            var groupMedicalPractice = new DataAccess.GroupMedicalPractice
            {
                GroupMedicalPracticeId = Id = Guid.NewGuid(),
                GroupId = GroupId,
                MedicalPracticeId = MedicalPracticeId
            };
            context.GroupMedicalPractice.AddObject(groupMedicalPractice);
        }
        internal static void RemoveMedicalPractices(MedilabEntities context, Guid groupId)
        {
            var medicalPractices = (from p in context.GroupMedicalPractice where p.GroupId == groupId select p).ToList();
            foreach (var medicalPractice in medicalPractices)
            {
                context.DeleteObject(medicalPractice);
            }
        }

        #endregion
    }
}
