using eCommerceNET.Entities;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using System.Collections.Generic;

namespace eCommerceNET.Services.Concrete
{
	public class ProductService : IProductService
	{
		private DataContext _context;

		public ProductService(DataContext context)
		{
			_context = context;
		}

		public IEnumerable<Product> GetAll()
		{
			return _context.Products;
		}

		public Product GetById(int id)
		{
			return _context.Products.Find(id);
		}

		public Product Create(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();

			return product;
		}

		public Product Update(Product productParam)
		{
			var product = _context.Products.Find(productParam.Id);

			product.ImagePath = productParam.ImagePath;
			product.Name = productParam.Name;
			product.Price = productParam.Price;
			product.Tag = productParam.Tag;

			_context.Products.Update(product);
			_context.SaveChanges();

			return product;
		}

		public void Delete(int id)
		{
			var product =_context.Products.Find(id);
			_context.Products.Remove(product);
			_context.SaveChanges();
		}
	}
}
