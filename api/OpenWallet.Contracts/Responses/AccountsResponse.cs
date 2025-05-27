using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Contracts.Responses
{
    public class AccountsResponse
    {
        public required IEnumerable<AccountResponse> Items { get; init; } = Enumerable.Empty<AccountResponse>();
    }
}
