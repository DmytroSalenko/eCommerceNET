using eCommerceNET.Entities;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace eCommerceNET.Services.Concrete
{
	public class CommentService : ICommentService
	{
		private DataContext _context;

		public CommentService(DataContext context)
		{
			_context = context;
		}

		public IEnumerable<Comment> GetAll()
		{
			return _context.Comments.OrderByDescending(comment => comment.Date);
		}

		public Comment GetById(int id)
		{
			return _context.Comments.Find(id);
		}

		public Comment Create(Comment comment)
		{
			_context.Comments.Add(comment);
			_context.SaveChanges();

			return comment;
		}

		public Comment Update(Comment commentParam)
		{
			var comment = _context.Comments.Find(commentParam.Id);

			comment.Rating = commentParam.Rating;
			comment.UserName = commentParam.UserName;

			_context.Comments.Update(comment);
			_context.SaveChanges();
			return comment;
		}

		public void Delete(int id)
		{
			var comment = _context.Comments.Find(id);
			_context.Comments.Remove(comment);
			_context.SaveChanges();
		}
	}
}
