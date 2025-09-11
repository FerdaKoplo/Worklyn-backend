namespace Worklyn_backend.Domain.ValueObjects.Profile
{
    public class FullNameVO
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private FullNameVO() { }
        public FullNameVO(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name required");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Last name required");

            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj) => obj is FullNameVO other &&
                                                  FirstName == other.FirstName &&
                                                  LastName == other.LastName;

        public override int GetHashCode() => HashCode.Combine(FirstName, LastName);
    }
}
