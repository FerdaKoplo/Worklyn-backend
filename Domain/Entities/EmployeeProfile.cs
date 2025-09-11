using Worklyn_backend.Domain.Enum.EmployeeProfile;

namespace Worklyn_backend.Domain.Entities
{
    public class EmployeeProfile : BaseEntity
    {
        public int EmployeeProfileId { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        // Personal info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string NationalIDNumber { get; set; }   
        public string? PassportNumber { get; set; } // for foreign


        // contact
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? SecondaryPhoneNumber { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }


        // Emergency
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactRelation { get; set; }

        // other necessary things
        public BloodType BloodType { get; set; }
        public Religion? Religion { get; set; }            
        public string PhotoUrl { get; set; }
    }
}
