using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNET.Dtos
{
    public class ProductSizeDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public bool IsAvailable { get; set; }
    }
}
