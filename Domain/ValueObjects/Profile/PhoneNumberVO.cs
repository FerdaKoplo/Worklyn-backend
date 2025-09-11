namespace Worklyn_backend.Domain.ValueObjects.Profile
{
    public class PhoneNumberVO
    {
        public string Value { get; }

        public PhoneNumberVO(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be empty");
            Value = value;
        }
        public override bool Equals(object obj) => obj is PhoneNumberVO other && Value == other.Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
}
