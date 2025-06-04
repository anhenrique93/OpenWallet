using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Database
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task InitializeAsync()
        {
           await _context.Database.EnsureDeletedAsync();
           await _context.Database.EnsureCreatedAsync();
        }
    }
}
