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
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User item)
        {
            _userRepository.Add(item);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User GetByID(int id)
        {
            return _userRepository.Get(id);
        }

        public List<User> GetList()
        {
           return _userRepository.GetAll();
        }

        public void Update(User item)
        {
            _userRepository.Update(item);   
        }
    }
}
