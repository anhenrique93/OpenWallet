using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Contracts.Responses
{
    public class AccountCategoryResponse
    {
        public required Guid id { get; init; }
        public string Name { get; init; }
    }
}
