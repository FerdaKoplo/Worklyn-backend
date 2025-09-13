using System.ComponentModel.DataAnnotations;

namespace Worklyn_backend.Api.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        public Guid? CompanyId { get; set; }
    }
}
