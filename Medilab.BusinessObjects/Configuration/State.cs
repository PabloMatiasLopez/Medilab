using System;
using System.Collections.Generic;
using System.Linq;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Configuration
{
    public class State
    {
        #region Properties

        public int Id { set; get; }
        public string Name { set; get; }
        #endregion
        public static IEnumerable<State> GetList()
        {
            using (var context = new MedilabEntities())
            {
                var states = (from state in context.State select state).ToList();
                return states.Select(s => new State
                                              {
                                                  Id = s.StateId,
                                                  Name = s.StateName
                                              }).OrderBy(s=>s.Name).ToList();
            }
        }

        internal static State GetState(int id, MedilabEntities context)
        {
            return (from s in context.State
                    where s.StateId == id
                    select new State
                               {
                                   Id = s.StateId,
                                   Name = s.StateName
                               }).FirstOrDefault();
        }
    }
}
