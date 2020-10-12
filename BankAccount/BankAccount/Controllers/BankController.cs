using BankAccount.Contract;
using BankAccount.Contract.Request;
using BankAccount.Contract.Response;
using BankAccount.Domain;
using BankAccount.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Controllers
{
    public class BankController:ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }
        [HttpGet(ApiRoutes.Accounts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bankService.GetAccountsAsync());
        }

        [HttpPost(ApiRoutes.Accounts.Create)]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest accountRequest)
        {
            var account = new Account
            {
                Owner_Name = accountRequest.Owner_Name,
                Address = accountRequest.Address,
                Balance = 0,
                Creation_Date = DateTime.Now
            };

            await _bankService.CreateAccountAsync(account);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Accounts.Get.Replace("{accountNumber}", account.Account_Number.ToString());
            var response = new AccountResponse {Account_Number=account.Account_Number};

            return Created(locationUri, response);
        }
      
        [HttpPut(ApiRoutes.Accounts.Update)]
        public async Task<IActionResult> Update([FromRoute] int accountNumber, [FromRoute] double amount)
        {
            var account = await _bankService.GetAccountByIdAsync(accountNumber);
            if (account == null)
                return NotFound();
            account.Balance += amount;
            var updated = await _bankService.UpdateAccountAsync(account);
            if (updated)
                return Ok(account);
            return NotFound();
        }


    }
}
