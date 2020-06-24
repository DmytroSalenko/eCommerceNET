using eCommerceNET.Entities;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using System.Collections.Generic;

namespace eCommerceNET.Services.Concrete
{
	public class CartService : ICartService
	{
		private DataContext _context;

		public CartService(DataContext context)
		{
			_context = context;
		}

		public IEnumerable<Cart> GetAll()
		{
			return _context.Carts;
		}

		public Cart GetById(int id)
		{
			return _context.Carts.Find(id);
		}

		public Cart Create(Cart cart)
		{
			_context.Carts.Add(cart);
			_context.SaveChanges();

			return cart;
		}

		public Cart Update(Cart cartParam)
		{
			var cart = _context.Carts.Find(cartParam.Id);

			cart.UserId = cartParam.UserId;

			_context.Carts.Update(cart);
			_context.SaveChanges();

			return cart;
		}

		public void Delete(int id)
		{
			var cart = _context.Carts.Find(id);
			_context.Carts.Remove(cart);
			_context.SaveChanges();
		}
	}
}
