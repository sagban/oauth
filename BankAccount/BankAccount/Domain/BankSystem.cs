using BankAccount.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Domain
{
    public class BankSystem
    {
        public DataContext _dataContext;
        public BankSystem(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Withdraw(double amount,int accountNumber)
        {
                var account =  _dataContext.Accounts.Find(accountNumber);
                account.Balance -= amount;
            var updated= _dataContext.SaveChanges();
            return updated > 0;
        }
        public async Task<bool> Deposit(double amount, int accountNumber)
        {
            var account = await _dataContext.Accounts.FindAsync(accountNumber);
            account.Balance += amount;
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

    }
}
