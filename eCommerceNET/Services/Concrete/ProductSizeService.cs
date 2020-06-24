using eCommerceNET.Entities;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using System.Collections.Generic;

namespace eCommerceNET.Services.Concrete
{
	public class ProductSizeService : IProductSizeService
	{
		private DataContext _context;

		public ProductSizeService(DataContext context)
		{
			_context = context;
		}

		public IEnumerable<ProductSize> GetAll()
		{
			return _context.ProductSizes;
		}

		public ProductSize GetById(int id)
		{
			return _context.ProductSizes.Find(id);
		}

		public ProductSize Create(ProductSize productSize)
		{
			_context.ProductSizes.Add(productSize);
			_context.SaveChanges();

			return productSize;
		}

		public ProductSize Update(ProductSize productSizeParam)
		{
			var productSize = _context.ProductSizes.Find(productSizeParam);

			productSize.IsAvailable = productSizeParam.IsAvailable;
			productSize.ProductId = productSizeParam.ProductId;

			_context.ProductSizes.Update(productSize);
			_context.SaveChanges();

			return productSize;
		}

		public void Delete(int id)
		{
			var productSize = _context.ProductSizes.Find(id);
			_context.ProductSizes.Remove(productSize);
			_context.SaveChanges();
		}
	}
}
