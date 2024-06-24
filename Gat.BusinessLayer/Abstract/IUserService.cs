using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface IUserService
    {
        User GetByID(int id);
        List<User> GetList();
        void Add(User item);
        void Update(User item);
        void Delete(int id);
    }
}
