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
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(Order item)
        {
            _orderRepository.Add(item); 
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }

        public Order GetByID(int id)
        {
            return _orderRepository.Get(id);
        }

        public List<Order> GetList()
        {
            return _orderRepository.GetAll();
        }

        public void Update(Order item)
        {
            _orderRepository.Update(item);
        }
    }
}
