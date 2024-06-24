using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }        
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string State { get; set; }
        public string Adress { get; set; }

		[ForeignKey(nameof(User))]
		public int? UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
