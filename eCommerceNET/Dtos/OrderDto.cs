using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNET.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DeliveryInfoId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
