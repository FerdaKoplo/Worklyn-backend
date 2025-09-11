using Worklyn_backend.Domain.Enum.Token;
using Worklyn_backend.Domain.ValueObjects.Auth;

namespace Worklyn_backend.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public TokenVO Token { get; set; }
    }
}
