using AutoMapper;
using Worklyn_backend.Api.DTOs.Attendance;
using Worklyn_backend.Domain.Entities;
using Worklyn_backend.Domain.Enum.Attendance;
using Worklyn_backend.Shared.Helpers;

namespace Worklyn_backend.Application.Mappings.AttendanceMap
{
    public class AttendanceMappingProfile : Profile
    {
        public AttendanceMappingProfile()
        {
            CreateMap<string, AttendanceStatus>()
                .ConvertUsing(new StringToEnumConverter<AttendanceStatus>(AttendanceStatus.Absent));

            CreateMap<Attendance, AttendanceDTO>()
               .ForMember(dest => dest.EmployeeName,
                   opt => opt.MapFrom(src => src.Employee != null
                       ? $"{src.Employee.Profile.Name.FirstName} {src.Employee.Profile.Name.LastName}"
                       : string.Empty))
               .ForMember(dest => dest.Status,
                   opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateAttendanceDTO, Attendance>()
                .ForMember(dest => dest.AttendanceId, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => AttendanceStatus.Absent));

            CreateMap<UpdateAttendanceDTO, Attendance>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
