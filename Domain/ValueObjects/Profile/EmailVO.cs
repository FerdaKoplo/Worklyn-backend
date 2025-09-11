namespace Worklyn_backend.Domain.ValueObjects.Profile
{
    public class EmailVO
    {
        public string Value { get; private set; }

        private EmailVO() { }
        public EmailVO(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Invalid email");
            Value = value;
        }

        public override bool Equals(object obj) => obj is EmailVO other && Value == other.Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
}
