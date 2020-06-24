using System.Collections.Generic;

namespace eCommerceNET.Entities
{
	public class User
    {
        public int Id { get; set; }
        public int? DeliveryInfoId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual Cart Cart { get; set; }
		public virtual DeliveryInfo DeliveryInfo { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
    }
}
