using eCommerceNET.Entities;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using System.Collections.Generic;

namespace eCommerceNET.Services.Concrete
{
	public class OrderService : IOrderService
	{
		private DataContext _context;

		public OrderService(DataContext context)
		{
			_context = context;
		}

		public IEnumerable<Order> GetAll()
		{
			return _context.Orders;
		}

		public Order GetById(int id)
		{
			return _context.Orders.Find(id);
		}

		public Order Create(Order order)
		{
			_context.Orders.Add(order);
			_context.SaveChanges();

			return order;
		}

		public Order Update(Order orderParam)
		{
			var order = _context.Orders.Find(orderParam.Id);

			order.DeliveryInfoId = orderParam.DeliveryInfoId;
			order.IsPaid = orderParam.IsPaid;

			_context.Orders.Update(order);
			_context.SaveChanges();

			return order;
		}

		public void Delete(int id)
		{
			var order = _context.Orders.Find(id);
			_context.Orders.Remove(order);
			_context.SaveChanges();
		}
	}
}
