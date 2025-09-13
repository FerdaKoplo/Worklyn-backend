using Worklyn_backend.Api.DTOs.EmployeeProfile;

namespace Worklyn_backend.Application.Interfaces
{
    public interface IEmployeeProfileService
    {
        Task<IEnumerable<EmployeeProfileDTO>> GetAllProfileAsync(EmployeeProfileFilterDTO? filter = null);
        Task<EmployeeProfileDTO> GetProfileByIdAsync(int id);
        Task<EmployeeProfileDTO> GetProfileByEmployeeIdAsync(Guid employeeId);
        Task<EmployeeProfileDTO> CreateProfileAsync(CreateEmployeeProfileDTO dto);
        Task<EmployeeProfileDTO> UpdateProfileAsync(int id, UpdateEmployeeProfileDTO dto);
        Task DeleteProfileAsync(int id);
        //Task<IEnumerable<EmployeeProfileDTO>> SearchProfilesAsync(EmployeeProfileFilterDTO filter);
    }
}
