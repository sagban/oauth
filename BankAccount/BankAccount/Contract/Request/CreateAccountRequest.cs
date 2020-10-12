using BankAccount.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Contract.Request
{
    public class CreateAccountRequest
    {
        public string Owner_Name { get; set; }
        public Address Address { get; set; }
    }
}
