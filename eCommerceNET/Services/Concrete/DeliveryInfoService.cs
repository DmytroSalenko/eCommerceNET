using eCommerceNET.Entities;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using System.Collections.Generic;

namespace eCommerceNET.Services.Concrete
{
	public class DeliveryInfoService : IDeliveryInfoService
	{
		private DataContext _context;

		public DeliveryInfoService(DataContext context)
		{
			_context = context;
		}

		public IEnumerable<DeliveryInfo> GetAll()
		{
			return _context.DeliveryInfos;
		}

		public DeliveryInfo GetById(int id)
		{
			return _context.DeliveryInfos.Find(id);
		}

		public DeliveryInfo Create(DeliveryInfo deliveryInfo)
		{
			_context.DeliveryInfos.Add(deliveryInfo);
			_context.SaveChanges();

			return deliveryInfo;
		}

		public DeliveryInfo Update(DeliveryInfo deliveryInfoParam)
		{
			var deliveryInfo = _context.DeliveryInfos.Find(deliveryInfoParam.Id);

			deliveryInfo.AddressLine = deliveryInfoParam.AddressLine;
			deliveryInfo.City = deliveryInfoParam.City;
			deliveryInfo.PostalCode = deliveryInfoParam.PostalCode;
			deliveryInfo.Province = deliveryInfoParam.Province;
			deliveryInfo.UserName = deliveryInfoParam.UserName;

			_context.DeliveryInfos.Update(deliveryInfo);
			_context.SaveChanges();

			return deliveryInfo;
		}

		public void Delete(int id)
		{
			var deliveryInfo = _context.DeliveryInfos.Find(id);
			_context.DeliveryInfos.Remove(deliveryInfo);
			_context.SaveChanges();
		}
	}
}
