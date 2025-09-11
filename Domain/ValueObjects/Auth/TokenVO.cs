using Worklyn_backend.Domain.Enum.Token;

namespace Worklyn_backend.Domain.ValueObjects.Auth
{
    public class TokenVO
    {
        public string Token { get; }
        public DateTime ExpiresAt { get; }
        public TokenStatus Status { get; private set; }

        public TokenVO(string token, DateTime expiresAt, TokenStatus status = TokenStatus.Active)
        {
            if (string.IsNullOrWhiteSpace(token)) throw new ArgumentException("Token required");

            Token = token;
            ExpiresAt = expiresAt;
            Status = status;
        }

        public bool IsExpired() => DateTime.UtcNow > ExpiresAt;
        public void Revoke() => Status = TokenStatus.Revoked;
    }
}
