using Microsoft.EntityFrameworkCore;
using OpenWallet.Application.Database;
using OpenWallet.Application.Models;

namespace OpenWallet.Application.Repositories
{
    public class AccountCategoryRepository : IAccountCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(AccountCategory category, CancellationToken token = default)
        {
            await _context.AccountCategories.AddAsync(category, token);
            await _context.SaveChangesAsync(token);
            return true;
        }

        public async Task<AccountCategory?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _context.AccountCategories.FirstOrDefaultAsync(x => x.Id == id, token);
        }

        public async Task<IEnumerable<AccountCategory>> GetAllAsync(CancellationToken token = default)
        {
            return await _context.AccountCategories.ToListAsync(token);
        }

        public async Task<bool> UpdateAsync(AccountCategory category, CancellationToken token = default)
        {
            var existing = await _context.AccountCategories.FirstOrDefaultAsync(x => x.Id == category.Id, token);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(category);

            await _context.SaveChangesAsync(token);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
        {
            var categoryToRemove = await _context.AccountCategories.FirstOrDefaultAsync(x => x.Id == id, token);
            if (categoryToRemove == null)
                return false;

            _context.AccountCategories.Remove(categoryToRemove);
            await _context.SaveChangesAsync(token);
            return true;
        }
    }
}
