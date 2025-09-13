using Worklyn_backend.Domain.Entities;

namespace Worklyn_backend.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        RefreshToken GenerateRefreshToken(User user);
    }
}
