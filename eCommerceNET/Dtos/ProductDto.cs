using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNET.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Tag { get; set; }
        public string[] ImagePath { get; set; }
    }
}
