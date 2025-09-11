namespace Worklyn_backend.Domain.ValueObjects.Finance
{
    public class MoneyVO
    {
        public decimal Amount { get; }

        public MoneyVO(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Amount cannot be negative");
            Amount = amount;
        }

        public override bool Equals(object obj) => obj is MoneyVO other && Amount == other.Amount;
        public override int GetHashCode() => Amount.GetHashCode();
    }
}

