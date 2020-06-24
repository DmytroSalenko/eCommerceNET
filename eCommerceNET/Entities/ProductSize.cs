namespace eCommerceNET.Entities
{
	public class ProductSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public bool IsAvailable { get; set; }
		public virtual Product Product { get; set; }
    }
}
