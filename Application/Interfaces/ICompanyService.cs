using Worklyn_backend.Api.DTOs.Company;

namespace Worklyn_backend.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetAllCompaniesAsync();
        Task<CompanyDTO> GetCompanyByIdAsync(Guid companyId);
        Task<CompanyDTO> CreateCompanyAsync(CreateCompanyDTO dto);
        Task<CompanyDTO> UpdateCompanyAsync(Guid companyId, UpdateCompanyDTO dto);
        Task DeleteCompanyAsync(Guid companyId);
    }
}
