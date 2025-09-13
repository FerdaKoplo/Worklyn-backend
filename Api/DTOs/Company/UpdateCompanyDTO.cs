namespace Worklyn_backend.Api.DTOs.Company
{
    public class UpdateCompanyDTO
    {
        public string Name { get; set; }
        public string LegalName { get; set; }
        public string RegistrationNumber { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
