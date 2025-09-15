using Worklyn_backend.Api.DTOs.Employee;
using Worklyn_backend.Shared.Wrappers;

namespace Worklyn_backend.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO dto);
        Task<EmployeeDTO> UpdateEmployeeAsync(Guid id, UpdateEmployeeDTO dto);
        Task DeleteEmployeeAsync(Guid id);
        Task<PagedResult<EmployeeDTO>> SearchEmployeeAsync(EmployeeFilterDTO filter);

    }
}
