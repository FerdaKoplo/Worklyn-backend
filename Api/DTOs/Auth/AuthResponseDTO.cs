using Worklyn_backend.Domain.Enum.User;

namespace Worklyn_backend.Api.DTOs.Auth
{
    public class AuthResponseDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }   
        public UserStatus Status { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiresAt { get; set; }
    }
}
