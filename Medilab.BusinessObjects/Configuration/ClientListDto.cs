using Medilab.BusinessObjects.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.Configuration
{
    public class ClientListDto
    {
        public Guid Id { set; get; }
        public DocumentType DocumentType { set; get; }
        public int ClientNumber { set; get; }
        public string Name { get; set; }
        public string Cuit { get; set; }
        public string AditionalInformation { get; set; }
    }
}
