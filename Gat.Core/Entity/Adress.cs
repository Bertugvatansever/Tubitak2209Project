using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Entity
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }        
        public string AdressType { get; set; }
        public string Street { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

		[ForeignKey(nameof(User))]
		public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
