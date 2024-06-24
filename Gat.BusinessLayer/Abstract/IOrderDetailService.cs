using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface IOrderDetailService
    {
        OrderDetail GetByID(int id);
        List<OrderDetail> GetList();
        void Add(OrderDetail item);
        void Update(OrderDetail item);
        void Delete(int id);
    }
}
