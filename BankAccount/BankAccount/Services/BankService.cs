using BankAccount.Data;
using BankAccount.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Domain
{
    public class BankService : IBankService
    {
        private readonly DataContext _dataContext;

        public BankService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateAccountAsync(Account account)
        {
            await _dataContext.Accounts.AddAsync(account);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteAccountAsync(int accountNumber)
        {
            var post = await GetAccountByIdAsync(accountNumber);
            if (post == null)
                return false;
            _dataContext.Accounts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Account> GetAccountByIdAsync(int accountNumber)
        {
            return await _dataContext.Accounts.SingleOrDefaultAsync(x => x.Account_Number ==accountNumber );
        }

        public async  Task<List<Account>> GetAccountsAsync()
        {
            return await _dataContext.Accounts.ToListAsync();
        }

        public async Task<bool> UpdateAccountAsync(Account accountToUpdate)
        {
            _dataContext.Accounts.Update(accountToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
