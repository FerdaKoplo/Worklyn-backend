using Worklyn_backend.Api.DTOs.Employee;

namespace Worklyn_backend.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(EmployeeSearchFilterDTO? filter = null);
        Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO dto);
        Task<EmployeeDTO> UpdateEmployeeAsync(Guid id, UpdateEmployeeDTO dto);
        Task DeleteEmployeeAsync(Guid id);
    }
}
