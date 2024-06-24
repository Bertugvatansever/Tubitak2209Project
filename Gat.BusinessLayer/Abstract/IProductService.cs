using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface IProductService
    {
        Product GetByID(int id);
        List<Product> GetList();
        void Add(Product item);
        void Update(Product item);
        void Delete(int id);
		List<Product> GetProductsByUserId(int id);
		
	}
}
