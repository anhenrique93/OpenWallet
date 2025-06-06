namespace OpenWallet.Contracts.Requests
{
    public class CreateAccountRequest
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required string Currency { get; init; }
        public required Guid CategoryId { get; init; }
        public decimal InitialAmount { get; init; }
    }
}
