using Worklyn_backend.Api.DTOs.Company;

namespace Worklyn_backend.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetAllAsync();
        Task<CompanyDTO> GetByIdAsync(Guid companyId);
        Task<CompanyDTO> CreateAsync(CreateCompanyDTO dto);
        Task<CompanyDTO> UpdateAsync(Guid companyId, UpdateCompanyDTO dto);
        Task DeleteAsync(Guid companyId);
    }
}
