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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private Context _context;

		public OrderRepository(Context context)
		{
			_context = context;
		}

		public void Add(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges(); 
        }

        public Order Get(int id)
        {
            var order = _context.Orders.Find(id);
            return order;
        }

        public List<Order> GetAll()
        {
            var orderList = _context.Orders.ToList();
            return orderList;   
        }

        public void Update(Order item)
        {
            _context.Orders.Update(item);
            _context.SaveChanges();
        }
    }
}
