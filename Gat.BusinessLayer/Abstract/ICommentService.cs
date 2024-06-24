using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface ICommentService
    {
        Comment GetByID(int id);
        List<Comment> GetList();
        void Add(Comment item);
        void Update(Comment item);
        void Delete(int id);
    }
}
