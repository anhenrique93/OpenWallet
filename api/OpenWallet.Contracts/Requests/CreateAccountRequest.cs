using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Contracts.Requests
{
    public record CreateAccountRequest(
        string Name,
        string Description,
        string Currency,
        string Type,
        decimal InitialBalance = 0m
    );
}
