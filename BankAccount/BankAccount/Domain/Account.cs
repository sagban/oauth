using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Domain
{
    public class Account
    {
        [Key]
        public int Account_Number { get; set; }
        public string Owner_Name { get; set; }
        public double Balance { get; set; }

        public DateTime Creation_Date { get; set; }

        [ForeignKey("Address")]
        public int Address_Id { get; set; }

        public Address Address { get; set; }

    }
}
