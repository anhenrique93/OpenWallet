using OpenWallet.Application.Enums;
using OpenWallet.Application.ValueObjects;

namespace OpenWallet.Application.Models
{
    public class Transation
    {
        public Guid Id { get; init; } = new Guid();
        public string Name { get; init; }
        public string? Description { get; init; }
        public TransationCategory Category { get; init; }
        public TransationType Type { get; init; }
        public Money Value { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}