using AutoMapper;
using Worklyn_backend.Api.DTOs.Employee;
using Worklyn_backend.Domain.Entities;
using Worklyn_backend.Domain.Enum.Employee;

namespace Worklyn_backend.Application.Mappings.EmployeeMap
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeDTO, Employee>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<EmployeeStatus>(src.Status)))
                .ForMember(dest => dest.EmployementType, opt => opt.MapFrom(src => Enum.Parse<EmployementType>(src.EmployementType)));

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.EmployementType, opt => opt.MapFrom(src => src.EmployementType.ToString()));

            CreateMap<UpdateEmployeeDTO, Employee>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<EmployeeStatus>(src.Status)))
                .ForMember(dest => dest.EmployementType, opt => opt.MapFrom(src => Enum.Parse<EmployementType>(src.EmployementType)));
        }
    }
}
