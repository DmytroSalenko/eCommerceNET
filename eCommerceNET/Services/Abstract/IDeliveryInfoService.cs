using eCommerceNET.Entities;
using System.Collections.Generic;

namespace eCommerceNET.Services.Abstract
{
	public interface IDeliveryInfoService
	{
		IEnumerable<DeliveryInfo> GetAll();
		DeliveryInfo GetById(int id);
		DeliveryInfo Create(DeliveryInfo deliveryInfo);
		DeliveryInfo Update(DeliveryInfo deliveryInfo);
		void Delete(int id);
	}
}
