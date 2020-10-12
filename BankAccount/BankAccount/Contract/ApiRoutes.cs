using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Contract
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        public static class Accounts
        {
            public const string GetAll = Base + "/accounts";
            public const string Get = Base + "/accounts/{accountNumber}";
            public const string Create = Base + "/accounts";
            public const string Update= Base + "/accounts/{accountNumber}/{amount}";
            

        }
    }
}
