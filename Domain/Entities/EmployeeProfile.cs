using System.Net;
using Worklyn_backend.Domain.Enum.EmployeeProfile;
using Worklyn_backend.Domain.ValueObjects.Profile;

namespace Worklyn_backend.Domain.Entities
{
    public class EmployeeProfile : BaseEntity
    {
        public int EmployeeProfileId { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        // Personal info
        public FullNameVO Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string NationalIDNumber { get; set; }   
        public string? PassportNumber { get; set; } // for foreign


        // contact
        public EmailVO Email { get; set; }
        public PhoneNumberVO PhoneNumber { get; set; }
        public PhoneNumberVO? SecondaryPhoneNumber { get; set; }
        public AddressVO Address { get; set; }


        // Emergency
        public EmergencyContactVO EmergencyContact { get; set; }

        // other necessary things
        public BloodType BloodType { get; set; }
        public Religion? Religion { get; set; }            
        public string PhotoUrl { get; set; }
    }
}
