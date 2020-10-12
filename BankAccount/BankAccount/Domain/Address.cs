using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Domain
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int  Pin { get; set; }
        public Account Account { get; set; }
    }
}
