namespace Worklyn_backend.Domain.ValueObjects.Profile
{
    public class AddressVO
    {
        public string Street { get; }
        public string City { get; }
        public string Province { get; }
        public string PostalCode { get; }
        public string Country { get; }

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
