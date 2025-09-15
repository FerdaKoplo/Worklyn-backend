using Worklyn_backend.Api.DTOs.Attendance;

namespace Worklyn_backend.Application.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDTO>> GetAllAsync();
        Task<AttendanceDTO> GetByIdAsync(Guid id);
        Task<AttendanceDTO> CreateAsync(CreateAttendanceDTO dto);
        Task<AttendanceDTO> UpdateAsync(Guid id, UpdateAttendanceDTO dto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<AttendanceDTO>> SearchAsync(AttendanceFilterDTO filter);
    }
}
