using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Entity
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }       
        public int Amount { get; set; }
        public decimal  Price { get; set; }

		[ForeignKey(nameof(Order))]
		public int? OrderId { get; set; }

		[ForeignKey(nameof(Product))]
		public int? ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }



    }
}
