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
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public void Add(Category item)
        {
            _categoryRepository.Add(item);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id); 
        }

        public Category GetByID(int id)
        {
            return _categoryRepository.Get(id); 
        }

        public List<Category> GetList()
        {
            return _categoryRepository.GetAll();
        }

        public void Update(Category item)
        {
           _categoryRepository.Update(item);
        }
    }
}
