namespace Worklyn_backend.Domain.ValueObjects.Profile
{
    public class AddressVO
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }

        private AddressVO() { }

        public AddressVO(string street, string city, string province, string postalCode, string country)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Street is required");
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City is required");
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Country is required");

            Street = street;
            City = city;
            Province = province;
            PostalCode = postalCode;
            Country = country;
        }

        public override bool Equals(object obj) =>
            obj is AddressVO other &&
            Street == other.Street &&
            City == other.City &&
            Province == other.Province &&
            PostalCode == other.PostalCode &&
            Country == other.Country;

        public override int GetHashCode() => HashCode.Combine(Street, City, Province, PostalCode, Country);
    }
}
