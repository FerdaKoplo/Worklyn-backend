using System.ComponentModel.DataAnnotations;

namespace Worklyn_backend.Api.DTOs.Auth
{
    public class RefreshTokenDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
