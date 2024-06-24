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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private Context _context;

		public ProductRepository(Context context)
		{
			_context = context;
		}

		public void Add(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges(); 

        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product Get(int id)
        {
            var product = _context.Products.Include(x => x.Category).Include(y=>y.User).Where(x=>x.Id==id).FirstOrDefault();
            return product;
        }

        public List<Product> GetAll()
        {
            var productList = _context.Products.Include(x=>x.Category).ToList();
            return productList;
        }

		public List<Product> GetProductsByUserId(int id)
		{
			var userProducts = _context.Products.Where(p => p.UserId == id).Include(x=>x.Category).ToList();
			return userProducts;
		}

		public void Update(Product item)
        {
            _context.Products.Update(item);
            _context.SaveChanges();
        }
    }
}
