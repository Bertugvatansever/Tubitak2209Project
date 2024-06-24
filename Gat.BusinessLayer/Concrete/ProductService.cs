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
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product item)
        {
            _productRepository.Add(item);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public Product GetByID(int id)
        {
            return _productRepository.Get(id);
        }

        public List<Product> GetList()
        {
           return _productRepository.GetAll();
        }

		public List<Product> GetProductsByUserId(int id)
		{
		  return	_productRepository.GetProductsByUserId(id); 
		}

		public void Update(Product item)
        {
            _productRepository.Update(item);
        }
    }
}
