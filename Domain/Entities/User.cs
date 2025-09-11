using System.ComponentModel.DataAnnotations;
using Worklyn_backend.Domain.Enum.User;

namespace Worklyn_backend.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }

        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        
        
        public string Role { get; set; } = "user";
        public UserStatus Status { get; set; } = UserStatus.PendingActivation;
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    }
}
