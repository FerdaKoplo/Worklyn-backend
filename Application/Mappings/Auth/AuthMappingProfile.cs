using AutoMapper;
using Worklyn_backend.Api.DTOs.Auth;
using Worklyn_backend.Domain.Entities;

namespace Worklyn_backend.Application.Mappings.Auth
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<RegisterDTO, User>()
               .ForMember(dest => dest.UserId, opt => opt.Ignore())
               .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
               .ForMember(dest => dest.Company, opt => opt.Ignore())
               .ForMember(dest => dest.RefreshTokens, opt => opt.Ignore());

            CreateMap<User, AuthResponseDTO>()
                .ForMember(dest => dest.AccessToken, opt => opt.Ignore()) 
                .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src =>
                    src.RefreshTokens.OrderByDescending(r => r.Token.ExpiresAt).FirstOrDefault().Token.Token))
                .ForMember(dest => dest.RefreshTokenExpiresAt, opt => opt.MapFrom(src =>
                    src.RefreshTokens.OrderByDescending(r => r.Token.ExpiresAt).FirstOrDefault().Token.ExpiresAt));
        }
    }
}
