using Worklyn_backend.Domain.Enum.Token;

namespace Worklyn_backend.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public TokenStatus Status { get; set; } = TokenStatus.Active;
    }
}
