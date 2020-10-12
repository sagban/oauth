using BankAccount.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Services
{
    public interface IBankService
    {
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetAccountByIdAsync(int accountNumber);
        Task<bool> CreateAccountAsync(Account account);
        Task<bool> UpdateAccountAsync(Account  accountToUpdate);
        Task<bool> DeleteAccountAsync( int accountNumber);
    }
}
