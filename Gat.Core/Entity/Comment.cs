
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Entity
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }              
        public string Content { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(User))]
        [Required]		
		public int UserId { get; set; }

		[ForeignKey(nameof(Product))]
        [Required]
		public int ProductId { get; set; }

        
        public virtual User User { get; set; }
       
        public virtual Product Product { get; set; }
    }
}
