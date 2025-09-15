namespace Worklyn_backend.Api.DTOs.EmployeeProfile
{
    public class EmployeeProfileFilterDTO
    {
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Nationality { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? BloodType { get; set; }
        public string? Religion { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
