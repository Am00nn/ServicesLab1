using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Models
{
    public class Transaction
    {

        [Key]
        public int Id { get; set; }  

        [Required]  
        public string sourceAccNumber { get; set; }    

        [Required]

        public decimal Amount { get; set; }

        [Required]

        public string Operation { get; set; }


        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }



    }
}
