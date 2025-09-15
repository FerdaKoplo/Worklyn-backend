namespace Worklyn_backend.Api.DTOs.EmployeeProfile
{
    public class CreateEmployeeProfileDTO
    {
        public Guid EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string NationalIDNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? SecondaryPhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string BloodType { get; set; }
        public string? Religion { get; set; }
        public string PhotoUrl { get; set; }
    }
}
