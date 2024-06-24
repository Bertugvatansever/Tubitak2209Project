using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface IOrderService
    {
        Order GetByID(int id);
        List<Order> GetList();
        void Add(Order item);
        void Update(Order item);
        void Delete(int id);
    }
}
