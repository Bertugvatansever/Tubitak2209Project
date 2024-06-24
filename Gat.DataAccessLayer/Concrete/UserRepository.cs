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
    public class UserRepository :GenericRepository<User>, IUserRepository
    {
        private Context _context;

		public UserRepository(Context context)
		{
			_context = context;
		}

		public void Add(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);  
            _context.SaveChanges();
        }

        public User Get(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public List<User> GetAll()
        {
            var userList= _context.Users.ToList();
            return userList;
        }

        public void Update(User item)
        {
			_context.Users.Update(item);
			_context.SaveChanges();
            
        }
    }
}
