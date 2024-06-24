using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Gender { get; set; }
        public string TelNo { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string WalletAdress { get; set; }
        public string PrivateKey { get; set; }



        public ICollection<Comment> Comments { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ProductOperations> ProductOperations { get; set; }
        public ICollection<Adress> Adresses { get; set; }   
        

    }
}
