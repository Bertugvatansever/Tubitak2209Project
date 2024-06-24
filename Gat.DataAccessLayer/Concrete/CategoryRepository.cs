using Gat.Core.Entity;
using Gat.DataAccessLayer.Abstract;
using Gat.DataAccessLayer.Concrete.GatContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.DataAccessLayer.Concrete
{
    public class CategoryRepository :GenericRepository<Category>, ICategoryRepository
    {
        private Context _context;

		public CategoryRepository(Context context)
		{
			_context = context;
		}

		public void Add(Category item)
        {
            _context.Categories.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);   
            _context.SaveChanges(); 
        }

        public Category Get(int id)
        {
            var category = _context.Categories.Find(id);
            return category;
        }

        public List<Category> GetAll()
        {
            var cetagoryList= _context.Categories.ToList();
            return cetagoryList;
        }

        public void Update(Category item)
        {
            _context.Categories.Update(item);
            _context.SaveChanges();
        }
    }
}
