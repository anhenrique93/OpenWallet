using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Contracts.Requests
{
    public class CreateAccountCategoryRequest
    {
        public required string Name { get; init; } // e.g., "Checking", "Savings", "Credit Card"
    }
}
