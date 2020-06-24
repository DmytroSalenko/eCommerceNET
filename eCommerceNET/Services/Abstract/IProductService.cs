using eCommerceNET.Entities;
using System.Collections.Generic;

namespace eCommerceNET.Services.Abstract
{
	public interface IProductService
	{
		IEnumerable<Product> GetAll();
		Product GetById(int id);
		Product Create(Product product);
		Product Update(Product product);
		void Delete(int id);
	}
}
