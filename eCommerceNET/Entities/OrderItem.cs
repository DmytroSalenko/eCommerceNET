﻿namespace eCommerceNET.Entities
{
	public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
		public virtual Order Order { get; set; }
		public virtual Product Product { get; set; }
		public virtual ProductSize Size { get; set; }
    }
}
