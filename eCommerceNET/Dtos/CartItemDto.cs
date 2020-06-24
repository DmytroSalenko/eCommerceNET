namespace eCommerceNET.Dtos
{
	public class CartItemDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
		public virtual ProductDto Product { get; set; }
		public virtual ProductSizeDto Size { get; set; }
    }
}
