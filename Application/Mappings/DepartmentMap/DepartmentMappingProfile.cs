using AutoMapper;
using Worklyn_backend.Api.DTOs.Department;
using Worklyn_backend.Domain.Entities;

namespace Worklyn_backend.Application.Mappings.DepartmentMap
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.Profile.Name : null))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<UpdateDepartmentDTO, Department>();
        }
    }
}
