using eCommerceNET.Entities;
using System.Collections.Generic;

namespace eCommerceNET.Services.Abstract
{
	public interface ICommentService
	{
		IEnumerable<Comment> GetAll();
		Comment GetById(int id);
		Comment Create(Comment comment);
		Comment Update(Comment comment);
		void Delete(int id);
	}
}
