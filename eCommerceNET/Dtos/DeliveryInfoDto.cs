using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNET.Dtos
{
    public class DeliveryInfoDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
    }
}
