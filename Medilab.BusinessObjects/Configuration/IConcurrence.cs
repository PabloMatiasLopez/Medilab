
namespace Medilab.BusinessObjects.Configuration
{
    public interface IConcurrence
    {
        /// <summary>
        /// The last update in the database 
        /// </summary>
        byte[] LastUpdated { set; get; }
    }
}
