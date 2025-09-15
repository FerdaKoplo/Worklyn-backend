using AutoMapper;
using AutoMapper.QueryableExtensions;
using Casbin.Persist;
using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Api.DTOs.Employee;
using Worklyn_backend.Api.DTOs.EmployeeProfile;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Application.Specifications;
using Worklyn_backend.Domain.Data;
using Worklyn_backend.Domain.Entities;
using Worklyn_backend.Shared.Wrappers;

namespace Worklyn_backend.Application.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;

        public EmployeeService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found");
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(Guid id, UpdateEmployeeDTO dto)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found");

            _mapper.Map<EmployeeDTO>(employee);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found");

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<EmployeeDTO>> SearchEmployeeAsync(EmployeeFilterDTO filter)
        {
            var query = _dbContext.Employees
                      .Include(e => e.Profile)
                      .AsQueryable();

            query = EmployeeSpecification.ApplyFilter(query, filter);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ProjectTo<EmployeeDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<EmployeeDTO>(items, totalCount, filter.PageNumber, filter.PageSize);

        }
    }
}
