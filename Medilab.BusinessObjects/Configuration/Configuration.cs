using Medilab.DataAccess;
using System.Linq;

namespace Medilab.BusinessObjects.Configuration
{
    public class Configuration
    {
        public string Name { set; get; }
        public string Value { set; get; }

        public static string GetValue(string name)
        {
            using (var context = new MedilabEntities())
            {
                var value = (from c in context.Configuration where c.Name == name select c.Value).FirstOrDefault();
                return value;
            }
        }
        public static void SetValue(string name, string value)
        {
            using (var context = new MedilabEntities())
            {
                var configuration = (from c in context.Configuration where c.Name == name select c).FirstOrDefault();
                if (configuration == null)
                {
                    var newConfiguration = new DataAccess.Configuration
                    {
                        Name = name,
                        Value = value
                    };
                    context.AddToConfiguration(newConfiguration);
                }
                else
                {
                    configuration.Value = value;
                }
                context.SaveChanges();
            }
        }
    }
}
