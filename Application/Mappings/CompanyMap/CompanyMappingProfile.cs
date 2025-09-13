using AutoMapper;
using Worklyn_backend.Api.DTOs.Company;
using Worklyn_backend.Domain.Entities;
using Worklyn_backend.Domain.ValueObjects.Profile;

namespace Worklyn_backend.Application.Mappings.CompanyMap
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CreateCompanyDTO, Company>(MemberList.None)
               .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new EmailVO(src.Email)))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => new PhoneNumberVO(src.PhoneNumber)))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src =>
                   new AddressVO(src.Street, src.City, src.Province, src.PostalCode, src.Country)))
               .ForMember(dest => dest.SubscriptionExpiry, opt => opt.MapFrom(src => DateTime.UtcNow.AddMonths(1)));

            CreateMap<Company, CompanyDTO>(MemberList.None)
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Value))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Address.Province))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.CurrentPlan, opt => opt.MapFrom(src => src.CurrentPlan.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<UpdateCompanyDTO, Company>(MemberList.None)
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new EmailVO(src.Email)))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => new PhoneNumberVO(src.PhoneNumber)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src =>
                    new AddressVO(src.Street, src.City, src.Province, src.PostalCode, src.Country)));
        }
    }
    }
}
