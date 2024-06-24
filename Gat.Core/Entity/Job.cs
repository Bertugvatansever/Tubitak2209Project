using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Entity
{
    public class Job
    {
        [Key]
        public int Id { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Pay { get; set; }
        public string JobAdress { get; set; }
        public DateTime Date  { get; set; }
        public int JobDuration { get; set; }
        public string JobImage { get; set; }

		[ForeignKey(nameof(User))]
		public int? UserId { get; set; }

        

        public virtual User User { get; set; }  
    }
}
