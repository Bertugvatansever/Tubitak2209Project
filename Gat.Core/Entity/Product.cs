using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }      
        public string ProductName { get; set; }    
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ProductType { get; set; }
        public string ProductImage { get; set; }

		[ForeignKey(nameof(User))]
		public int? UserId { get; set; }

		[ForeignKey(nameof(Category))]
		public int? CategoryId { get; set; }

        public string AdvertCode { get; set; }
        
        public virtual User User { get; set; }
        
        public virtual Category Category { get; set; }


        
        public ICollection<Comment> Comments { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductOperations> ProductOperations { get; set; }

    }
}
