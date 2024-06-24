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
    public class AdressRepository :GenericRepository<Adress>, IAdressRepository
    {
        private Context _context;

		public AdressRepository(Context context)
		{
			_context = context;
		}

		public void Add(Adress item)
        {
            _context.Adresses.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var adress = _context.Adresses.Find(id);
            _context.Adresses.Remove(adress);
            _context.SaveChanges();
        }

        public Adress Get(int id)
        {
            var adress = _context.Adresses.Find(id);
            return adress;
        }

        public List<Adress> GetAll()
        {
            var adressList = _context.Adresses.ToList();
            return adressList;
        }

        public void Update(Adress item)
        {
            _context.Adresses.Update(item);
            _context.SaveChanges();
        }
    }
}
