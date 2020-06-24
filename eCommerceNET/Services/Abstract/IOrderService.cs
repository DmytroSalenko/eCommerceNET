using eCommerceNET.Entities;
using System.Collections.Generic;

namespace eCommerceNET.Services.Abstract
{
	public interface IOrderService
	{
		IEnumerable<Order> GetAll();
		Order GetById(int id);
		Order Create(Order order);
		Order Update(Order order);
		void Delete(int id);
	}
}
