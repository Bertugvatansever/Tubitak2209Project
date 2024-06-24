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
    public class ProductOperationsService : IProductOperationsService
    {
        private IProductOperationsRepository _productOperationsRepository;

        public ProductOperationsService(IProductOperationsRepository productOperationsRepository)
        {
            _productOperationsRepository = productOperationsRepository;
        }

		public void Add(ProductOperations item)
		{
			_productOperationsRepository.Add(item);
		}

		public void Delete(int id)
		{
			_productOperationsRepository.Delete(id);
		}

		public ProductOperations GetByID(int id)
		{
			return _productOperationsRepository.Get(id);
		}

		public List<ProductOperations> GetList()
		{
			return _productOperationsRepository.GetAll();	
		}

		public void Update(ProductOperations item)
		{
			_productOperationsRepository.Update(item);
		}
	}
}
