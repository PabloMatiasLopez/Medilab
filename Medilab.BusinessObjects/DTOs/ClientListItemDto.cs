
using System;

namespace Medilab.BusinessObjects.DTOs
{
    public class ClientListItemDto : ListItemDto<Guid>
    {
        public int Number { set; get; }
    }
}
