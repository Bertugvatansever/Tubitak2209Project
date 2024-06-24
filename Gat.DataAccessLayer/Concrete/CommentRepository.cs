using Gat.Core.Entity;
using Gat.DataAccessLayer.Abstract;
using Gat.DataAccessLayer.Concrete.GatContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.DataAccessLayer.Concrete
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private Context _context;

		public CommentRepository(Context context)
		{
			_context = context;
		}

		public void Add(Comment item)
        {
            _context.Comments.Add(item);
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var comment = _context.Comments.Find(id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public Comment Get(int id)
        {
            var commnet = _context.Comments.Find(id);
            return commnet;
        }

        public List<Comment> GetAll()
        {
            var comment = _context.Comments.ToList();
            return comment;
        }

        public void Update(Comment item)
        {
            _context.Comments.Update(item);
            _context.SaveChanges();
        }
    }
}
