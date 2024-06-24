using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface IProductOperationsService
    {
        ProductOperations GetByID(int id);
        List<ProductOperations> GetList();
        void Add(ProductOperations item);
        void Update(ProductOperations item);
        void Delete(int id);
    }
}
