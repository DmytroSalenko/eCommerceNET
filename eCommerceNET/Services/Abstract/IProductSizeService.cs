using eCommerceNET.Entities;
using System.Collections.Generic;

namespace eCommerceNET.Services.Abstract
{
	public interface IProductSizeService
	{
		IEnumerable<ProductSize> GetAll();
		ProductSize GetById(int id);
		ProductSize Create(ProductSize productSize);
		ProductSize Update(ProductSize productSize);
		void Delete(int id);
	}
}
