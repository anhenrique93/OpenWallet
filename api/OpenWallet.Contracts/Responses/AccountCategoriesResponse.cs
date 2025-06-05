using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Contracts.Responses
{
    public class AccountCategoriesResponse
    {
        public required IEnumerable<AccountCategoryResponse> Items { get; init; } = Enumerable.Empty<AccountCategoryResponse>();
    }
}
