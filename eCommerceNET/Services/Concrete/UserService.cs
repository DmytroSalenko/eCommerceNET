using eCommerceNET.Entities;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eCommerceNET.Services.Concrete
{
	public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Email == email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User Create(string name, string email, string password, int? deliveryInfoId)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Email == email))
                throw new AppException("Email \"" + email + "\" is already taken");

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

			var user = new User
			{
				Name = name,
				Email = email,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				DeliveryInfoId = deliveryInfoId
			};

			_context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User UpdatePassword(int id, string password, string oldPassword)
        {
            var user = _context.Users.Find(id);

			if (user == null)
			{
				throw new AppException("User not found");
			}
            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                if (VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
				{
					CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

					user.PasswordHash = passwordHash;
					user.PasswordSalt = passwordSalt;
				}
            }

            _context.Users.Update(user);
            _context.SaveChanges();

			return user;
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }

}
