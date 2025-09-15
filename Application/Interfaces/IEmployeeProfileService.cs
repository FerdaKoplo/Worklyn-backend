using Worklyn_backend.Api.DTOs.EmployeeProfile;
using Worklyn_backend.Shared.Wrappers;

namespace Worklyn_backend.Application.Interfaces
{
    public interface IEmployeeProfileService
    {
        Task<IEnumerable<EmployeeProfileDTO>> GetAllProfileAsync();
        Task<EmployeeProfileDTO> GetProfileByIdAsync(int id);
        Task<EmployeeProfileDTO> GetProfileByEmployeeIdAsync(Guid employeeId);
        Task<EmployeeProfileDTO> CreateProfileAsync(CreateEmployeeProfileDTO dto);
        Task<EmployeeProfileDTO> UpdateProfileAsync(int id, UpdateEmployeeProfileDTO dto);
        Task DeleteProfileAsync(int id);
        Task<PagedResult<EmployeeProfileDTO>> SearchProfilesAsync(EmployeeProfileFilterDTO filter);
    }
}
