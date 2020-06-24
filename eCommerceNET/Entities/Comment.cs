using System;

namespace eCommerceNET.Entities
{
	public class Comment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string AttachmentUrls { get; set; }
		public virtual Product Product { get; set; }
		public virtual User User { get; set; }
    }
}
