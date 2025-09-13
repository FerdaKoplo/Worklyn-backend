using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Api.DTOs.Company;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Domain.Data;
using Worklyn_backend.Domain.Entities;

namespace Worklyn_backend.Application.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllCompaniesAsync()
        {
            var companies = await _dbContext.Companies.ToListAsync();
            return _mapper.Map<IEnumerable<CompanyDTO>>(companies);
        }

        public async Task<CompanyDTO> GetCompanyByIdAsync(Guid companyId)
        {
            var company = await _dbContext.Companies.FindAsync(companyId);
            if (company == null)
                throw new KeyNotFoundException("Company not found");

            return _mapper.Map<CompanyDTO>(company);
        }

        public async Task<CompanyDTO> CreateCompanyAsync(CreateCompanyDTO dto)
        {
            var company = _mapper.Map<Company>(dto);
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CompanyDTO>(company);
        }

        public async Task<CompanyDTO> UpdateCompanyAsync(Guid companyId, UpdateCompanyDTO dto)
        {
            var company = await _dbContext.Companies.FindAsync(companyId);
            if (company == null)
                throw new KeyNotFoundException(" Company not found ");


            _mapper.Map(dto, company);
            _dbContext.Companies.Update(company);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CompanyDTO>(dto);
        
        }


        public async Task DeleteCompanyAsync(Guid companyId)
        {
            var company = await _dbContext.Companies.FindAsync(companyId);
            if (company == null)
                throw new KeyNotFoundException("Company not found");

            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();
        }
    }
}