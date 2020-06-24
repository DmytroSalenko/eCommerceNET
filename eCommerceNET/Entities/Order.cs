using System;
using System.Collections.Generic;

namespace eCommerceNET.Entities
{
	public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DeliveryInfoId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
		public virtual User User { get; set; }
	}
}
