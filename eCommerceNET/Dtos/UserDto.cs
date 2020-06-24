namespace eCommerceNET.Dtos
{
	public class UserDto
    {
        public int Id { get; set; }
        public int? DeliveryInfoId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DeliveryInfoDto DeliveryInfo { get; set; }
    }
}
