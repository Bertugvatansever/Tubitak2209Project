using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        Category GetByID(int id);
        List<Category> GetList();
        void Add(Category item);
        void Update(Category item);
        void Delete(int id);
    }
}
