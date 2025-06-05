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

        public async Task<bool> CreateAsync(AccountCategory category)
        {
            await _context.AccountCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AccountCategory?> GetByIdAsync(Guid id)
        {
            return await _context.AccountCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AccountCategory>> GetAllAsync()
        {
            return await _context.AccountCategories.ToListAsync();
        }

        public async Task<bool> UpdateAsync(AccountCategory category)
        {
            var existing = await _context.AccountCategories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(category);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var categoryToRemove = await _context.AccountCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryToRemove == null)
                return false;

            _context.AccountCategories.Remove(categoryToRemove);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
