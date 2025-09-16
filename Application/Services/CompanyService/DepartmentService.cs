using AutoMapper;
using System.ComponentModel.Design;
using Worklyn_backend.Api.DTOs.Company;
using Worklyn_backend.Api.DTOs.Department;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Domain.Data;
using Worklyn_backend.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Worklyn_backend.Application.Services.CompanyService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = _dbContext.Departments.ToList();
            return _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
        }

        public async Task<DepartmentDTO> GetByIdAsync(Guid departmentId)
        {
            var department = await _dbContext.Companies.FindAsync(departmentId);
            if (department == null)
                throw new KeyNotFoundException("Company not found");

            return _mapper.Map<DepartmentDTO>(department);
        }

        public async Task<DepartmentDTO> CreateAsync(CreateDepartmentDTO dto)
        {
            var department = _mapper.Map<Department>(dto);
            _dbContext.Departments.Add(department);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DepartmentDTO>(department);
        }

        public async Task<DepartmentDTO> UpdateAsync(Guid departmentId, UpdateDepartmentDTO dto)
        {
            var department = await _dbContext.Departments.FindAsync(departmentId);
            if (department == null)
                throw new KeyNotFoundException(" Department not found ");

            _mapper.Map(dto, department);
            _dbContext.Update(dto);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DepartmentDTO>(dto);
        }

        public async Task DeleteAsync(Guid departmentId)
        {
            var deparment = await _dbContext.Departments.FindAsync(departmentId);
            if (deparment == null)
                throw new KeyNotFoundException("Department not found");

            _dbContext.Departments.Remove(deparment);
            await _dbContext.SaveChangesAsync();
        }

    }
}
