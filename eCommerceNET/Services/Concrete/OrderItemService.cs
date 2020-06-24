using eCommerceNET.Entities;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using System.Collections.Generic;

namespace eCommerceNET.Services.Concrete
{
	public class OrderItemService : IOrderItemService
	{
		private DataContext _context;

		public OrderItemService(DataContext context)
		{
			_context = context;
		}

		public IEnumerable<OrderItem> GetAll()
		{
			return _context.OrderItems;
		}

		public OrderItem GetById(int id)
		{
			return _context.OrderItems.Find(id);
		}

		public OrderItem Create(OrderItem orderItem)
		{
			_context.OrderItems.Add(orderItem);
			_context.SaveChanges();

			return orderItem;
		}

		public OrderItem Update(OrderItem orderItemParam)
		{
			var orderItem = _context.OrderItems.Find(orderItemParam.Id);

			orderItem.Quantity = orderItemParam.Quantity;

			_context.OrderItems.Update(orderItem);
			_context.SaveChanges();

			return orderItem;
		}

		public void Delete(int id)
		{
			var orderItem = _context.OrderItems.Find(id);
			_context.OrderItems.Remove(orderItem);
			_context.SaveChanges();
		}
	}
}
