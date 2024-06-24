using Gat.Core.Entity;
using Gat.DataAccessLayer.Abstract;
using Gat.DataAccessLayer.Concrete.GatContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.DataAccessLayer.Concrete
{
    public class ProductOperationsRepository : GenericRepository<ProductOperations>, IProductOperationsRepository
    {
        private Context _context;

		public ProductOperationsRepository(Context context)
		{
			_context = context;
		}

		public void Add(ProductOperations item)
        {
            _context.ProductOperations.Add(item);   
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var operation = _context.ProductOperations.Find(id);
            _context.ProductOperations.Remove(operation);   
            _context.SaveChanges(); 
        }

        public ProductOperations Get(int id)
        {
            var operation = _context.ProductOperations
                            .OrderByDescending(o => o.Id)
                            .FirstOrDefault();
            return operation;
        }

        public List<ProductOperations> GetAll()
        {
            var operationList = _context.ProductOperations.Include(x=>x.Product).ToList();
            return operationList;   
        }

        public void Update(ProductOperations item)
        {
            _context.ProductOperations.Update(item);
            _context.SaveChanges();
        }
    }
}
