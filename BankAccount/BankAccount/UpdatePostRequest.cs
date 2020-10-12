using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount
{
    public class UpdatePostRequest
    {
        public int AccountNumber { get; set; }
        public int Amount { get; set; }
    }
}
