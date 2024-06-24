using Gat.BusinessLayer.Abstract;
using Gat.Core.Entity;
using Gat.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Concrete
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(Comment item)
        {
            _commentRepository.Add(item);
        }

        public void Delete(int id)
        {
            _commentRepository.Delete(id);
        }

        public Comment GetByID(int id)
        {
           return _commentRepository.Get(id);
        }

        public List<Comment> GetList()
        {
            return _commentRepository.GetAll();
        }

        public void Update(Comment item)
        {
            _commentRepository.Update(item);    
        }
    }
}
