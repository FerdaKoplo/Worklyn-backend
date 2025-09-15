using Worklyn_backend.Api.DTOs.Department;
using Worklyn_backend.Shared.Wrappers;

namespace Worklyn_backend.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDTO> GetByIdAsync(Guid id);
        Task<DepartmentDTO> CreateAsync(CreateDepartmentDTO dto);
        Task<DepartmentDTO> UpdateAsync(Guid id, UpdateDepartmentDTO dto);
        Task DeleteAsync(Guid id);
        Task<PagedResult<DepartmentDTO>> SearchDepartmentsAsync(DepartmentFilterDTO filter);
    }
}
