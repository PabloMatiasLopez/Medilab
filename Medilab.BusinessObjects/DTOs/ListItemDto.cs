
namespace Medilab.BusinessObjects.DTOs
{
    public class ListItemDto <T>
    {
        public T Id { set; get; }
        public string Value { set; get; }
        public override string ToString()
        {
            return Value;
        }
    }
}
