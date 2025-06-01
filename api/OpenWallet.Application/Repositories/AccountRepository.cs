using Microsoft.EntityFrameworkCore;
using OpenWallet.Application.Database;
using OpenWallet.Application.Models;

namespace OpenWallet.Application.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly OpenWalletContext _context;

        public AccountRepository(OpenWalletContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Account account)
        {
            var existing = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == account.Id);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(account);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var accountToRemove = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (accountToRemove == null)
                return false;

            _context.Accounts.Remove(accountToRemove);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
