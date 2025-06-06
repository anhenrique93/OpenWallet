using Microsoft.EntityFrameworkCore;
using OpenWallet.Application.Database;
using OpenWallet.Application.Models;

namespace OpenWallet.Application.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Account account, CancellationToken token = default)
        {
            await _context.Accounts.AddAsync(account, token);
            await _context.SaveChangesAsync(token);
            return true;
        }

        public async Task<Account?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _context.Accounts
                .Include(a => a.Category)
                .FirstOrDefaultAsync(x => x.Id == id, token);
        }

        public async Task<IEnumerable<Account>> GetAllAsync(CancellationToken token = default)
        {
            return await _context.Accounts
                .Include(a => a.Category)
                .ToListAsync(token);
        }

        public async Task<bool> UpdateAsync(Account account, CancellationToken token = default)
        {
            var existing = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == account.Id);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(account);

            await _context.SaveChangesAsync(token);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
        {
            var accountToRemove = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id, token);
            if (accountToRemove == null)
                return false;

            _context.Accounts.Remove(accountToRemove);
            await _context.SaveChangesAsync(token);
            return true;
        }
    }
}
