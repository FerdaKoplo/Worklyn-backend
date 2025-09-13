using AutoMapper;
using Casbin.Persist;
using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Api.DTOs.Employee;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Domain.Data;
using Worklyn_backend.Domain.Entities;

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

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(EmployeeSearchFilterDTO filter = null)
        {
            var query = _dbContext.Employees
                .Include(e => e.Profile) 
                .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.Name))
                {
                    query = query.Where(e =>
                        e.Profile.Name.FirstName.Contains(filter.Name) ||
                        e.Profile.Name.LastName.Contains(filter.Name)
                    );
                }

                if (filter.DepartmentId.HasValue)
                    query = query.Where(e => e.DepartmentId == filter.DepartmentId.Value);

                if (filter.PositionId.HasValue)
                    query = query.Where(e => e.PositionId == filter.PositionId.Value);

                if (!string.IsNullOrWhiteSpace(filter.Status))
                    query = query.Where(e => e.Status.ToString() == filter.Status);
            }

            var employees = await query.ToListAsync();
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
    }
}
