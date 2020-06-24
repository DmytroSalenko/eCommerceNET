using eCommerceNET.Entities;
using System.Collections.Generic;

namespace eCommerceNET.Services.Abstract
{
	public interface IOrderItemService
	{
		IEnumerable<OrderItem> GetAll();
		OrderItem GetById(int id);
		OrderItem Create(OrderItem orderItem);
		OrderItem Update(OrderItem orderItem);
		void Delete(int id);
	}
}
