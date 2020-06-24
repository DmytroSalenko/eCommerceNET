using eCommerceNET.Entities;
using System.Collections.Generic;

namespace eCommerceNET.Services.Abstract
{
	public interface ICartItemService
	{
		IEnumerable<CartItem> GetAll();
		CartItem GetById(int id);
		CartItem Create(CartItem cartItem);
		CartItem Update(CartItem cartItem);
		void Delete(int id);
	}
}
