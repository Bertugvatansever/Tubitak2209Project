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
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public void Add(OrderDetail item)
        {
            _orderDetailRepository.Add(item);   
        }

        public void Delete(int id)
        {
            _orderDetailRepository.Delete(id);
        }

        public OrderDetail GetByID(int id)
        {
            return _orderDetailRepository.Get(id);
        }

        public List<OrderDetail> GetList()
        {
            return _orderDetailRepository.GetAll(); 
        }

        public void Update(OrderDetail item)
        {
            _orderDetailRepository.Update(item);    
        }
    }
}
