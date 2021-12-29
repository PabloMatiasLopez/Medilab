using System;

namespace Medilab.BusinessObjects.ListOfPrice
{
    public class PracticeGroupPriceDto
    {
        public Guid PriceId { set; get; }
        public Guid PracticeGroupId { set; get; }
        public double Price { set; get; }
        public Guid Client { set; get; }
    }
}
