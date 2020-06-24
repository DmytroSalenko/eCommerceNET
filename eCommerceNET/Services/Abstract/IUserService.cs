using eCommerceNET.Entities;
using System.Collections.Generic;

namespace eCommerceNET.Services.Abstract
{
	public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(string name, string email, string password, int? deliveryInfoId);
        User UpdatePassword(int id, string password, string oldPassword);
        void Delete(int id);
    }
}
