using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Model
{
    public class productCategoryModel
    {
        public List<Product> Products { get; set; }
        public List<Product> ProductsHire { get; set; }
        public List<Category> Categories { get; set;}
        public Product Product { get; set; }    
    }
}
