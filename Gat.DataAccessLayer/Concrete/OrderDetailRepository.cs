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
    public class OrderDetailRepository :GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private Context _context;

		public OrderDetailRepository(Context context)
		{
			_context = context;
		}

		public void Add(OrderDetail item)
        {
            _context.OrderDetails.Add(item);    
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var orderDetail = _context.OrderDetails.Find(id);
            _context.OrderDetails.Remove(orderDetail);  
            _context.SaveChanges();
        }

        public OrderDetail Get(int id)
        {
            var orderdetail = _context.OrderDetails.Find(id);
            return orderdetail; 
        }

        public List<OrderDetail> GetAll()
        {
            var orderdatailList = _context.OrderDetails.ToList();
            return orderdatailList;
        }

        public void Update(OrderDetail item)
        {
            _context.OrderDetails.Update(item);
            _context.SaveChanges();
        }
    }
}
