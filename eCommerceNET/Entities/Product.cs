using System.Collections.Generic;

namespace eCommerceNET.Entities
{
	public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Tag { get; set; }
        public string ImagePath { get; set; }
		public virtual ICollection<ProductSize> Sizes { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
    }
}
