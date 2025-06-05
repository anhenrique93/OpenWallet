using OpenWallet.Application.Enums;
using OpenWallet.Application.Helpers;

namespace OpenWallet.Application.Models
{
    public class TransationCategory
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; }
        public TransationType Type { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;

        public TransationCategory(string name, TransationType transationType)
        {
            Name = Guard.AgainstInvalidLength(name, 3, 20, nameof(name));
            Type = transationType;
        }

        public TransationCategory(Guid id, string name, TransationType transationType, DateTime createdAt, DateTime updatedAt)
            : this(name, transationType)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        protected TransationCategory()
        {
        }
    }
}
