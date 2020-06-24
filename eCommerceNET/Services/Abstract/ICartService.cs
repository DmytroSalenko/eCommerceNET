using eCommerceNET.Entities;
using System.Collections.Generic;

namespace eCommerceNET.Services.Abstract
{
	public interface ICartService
	{
		IEnumerable<Cart> GetAll();
		Cart GetById(int id);
		Cart Create(Cart cart);
		Cart Update(Cart cart);
		void Delete(int id);
	}
}
