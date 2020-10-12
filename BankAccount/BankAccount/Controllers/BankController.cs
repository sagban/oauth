using BankAccount.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Controllers
{
    public class BankController:ControllerBase
    {
        private BankSystem _bankSystem;
        public BankController(BankSystem bankSystem)
        {
            _bankSystem = bankSystem;
        }
        [HttpPost("api/v1/accounts")]
        public IActionResult Withdraw([FromBody] UpdatePostRequest postRequest)
        {
            return Ok(postRequest);

        }
    }
}
