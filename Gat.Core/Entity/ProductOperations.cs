using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Entity
{
    public class ProductOperations
    {
        [Key]
        public int Id { get; set; }      
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public DateTime DateStart { get; set; } 
        public DateTime DateEnd { get; set; }

		[ForeignKey(nameof(User))]
		public int? UserId { get; set; }

		[ForeignKey(nameof(Product))]
		public int? ProductId { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }    

    }
}
