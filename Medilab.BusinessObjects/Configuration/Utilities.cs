using System.Data;
using System.Text;
using Medilab.DataAccess;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Medilab.BusinessObjects.Configuration
{
    public static class Utilities
    {
        internal static string GetModifiedFields(MedilabEntities manager, string entityName)
        {
            var result = new StringBuilder();
            var updatedTables = manager.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            foreach (var objectStateEntry in updatedTables)
            {
                if (objectStateEntry.Entity != null && entityName != objectStateEntry.Entity.ToString()) continue;
                var modifiedColumns = objectStateEntry.GetModifiedProperties();
                foreach (var modifiedColumn in modifiedColumns)
                {
                    var originalValue = objectStateEntry.OriginalValues[modifiedColumn].ToString();
                    var newValue = objectStateEntry.CurrentValues[modifiedColumn].ToString();
                    if (originalValue != newValue)
                    {
                        result.Append(modifiedColumn).Append("::").Append(originalValue).Append("##").Append(
                            newValue).
                            Append("@@");
                    }
                }
            }
            var final = result.ToString();
            return final.EndsWith("@@") ? final.Remove(final.Length - 2, 2) : final;
        }

        public static int MaxCodeNumber()
        {
            using (var context = new MedilabEntities())
            {
                var codes = new List<int>();
                var exist = (from g in context.Group select g.GroupCode).Any();
                if (true)
                {
                    codes.Add((from g in context.Group select g.GroupCode).Max());
                }
                exist = (from p in context.MedicalPractice select p.PracticeCode).Any();
                if (exist)
                {
                    codes.Add((from p in context.MedicalPractice select p.PracticeCode).Max());
                }
                exist = (from i in context.AditionalItem select i.Code).Any();
                if (exist)
                {
                    codes.Add((from i in context.AditionalItem select i.Code).Max());
                }
                return codes.Count > 0 ? codes.Max() : 0;
            }
        }

        public static bool ExistCode(int code, Guid id)
        {
            using (var context = new MedilabEntities())
            {
                return (from p in context.MedicalPractice where p.PracticeCode == code && p.MedicalPracticeId != id select 1).Any() ||
                       (from g in context.Group where g.GroupCode == code && g.GroupId != id select 1).Any() ||
                       (from i in context.AditionalItem where i.Code == code && i.AditionaltemId != id select 1).Any();
            }
        } 
    }
}
