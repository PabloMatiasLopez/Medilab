using System;

namespace Medilab.BusinessObjects.ListOfPrice
{
    public class PriceListItemDto
    {
        public Guid Id { set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public double Price { set; get; }
    }
}
