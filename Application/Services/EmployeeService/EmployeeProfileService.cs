using AutoMapper;
using AutoMapper.QueryableExtensions;
using Casbin.Persist;
using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Api.DTOs.Company;
using Worklyn_backend.Api.DTOs.EmployeeProfile;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Application.Specifications;
using Worklyn_backend.Domain.Data;
using Worklyn_backend.Domain.Entities;
using Worklyn_backend.Shared.Wrappers;

namespace Worklyn_backend.Application.Services.EmployeeService
{
    public class EmployeeProfileService : IEmployeeProfileService
    {
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;

        public EmployeeProfileService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeProfileDTO>> GetAllProfileAsync()
        {
            var employeeProfiles = await _dbContext.EmployeeProfiles.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeProfileDTO>>(employeeProfiles);
        }

        public async Task<EmployeeProfileDTO> GetProfileByIdAsync(int id)
        {
            var profile = await _dbContext.EmployeeProfiles
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.EmployeeProfileId == id);

            if (profile == null)
                throw new KeyNotFoundException("Profile not found");

            return _mapper.Map<EmployeeProfileDTO>(profile);
        }

        public async Task<EmployeeProfileDTO> GetProfileByEmployeeIdAsync(Guid employeeId)
        {
            var profile = await _dbContext.EmployeeProfiles
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.EmployeeId == employeeId);

            if (profile == null)
                throw new KeyNotFoundException("Profile not found for the given employee");

            return _mapper.Map<EmployeeProfileDTO>(profile);
        }

        public async Task<EmployeeProfileDTO> CreateProfileAsync(CreateEmployeeProfileDTO dto)
        {
            var profile = _mapper.Map<EmployeeProfile>(dto);
            _dbContext.EmployeeProfiles.Add(profile);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeProfileDTO>(profile);
        }

        public async Task<EmployeeProfileDTO> UpdateProfileAsync(int id, UpdateEmployeeProfileDTO dto)
        {
            var profile = await _dbContext.EmployeeProfiles.FindAsync(id);
            if (profile == null)
                throw new KeyNotFoundException("Profile not found");

            _mapper.Map(dto, profile);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<EmployeeProfileDTO>(profile);
        }

        public async Task DeleteProfileAsync(int id)
        {
            var profile = await _dbContext.EmployeeProfiles.FindAsync(id);
            if (profile == null)
                throw new KeyNotFoundException("Profile not found");

            _dbContext.EmployeeProfiles.Remove(profile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<EmployeeProfileDTO>> SearchProfilesAsync(EmployeeProfileFilterDTO filter)
        {
            var query = _dbContext.EmployeeProfiles
                         .Include(p => p.Employee)
                         .AsQueryable();

            query = EmployeeProfileSpecifitaion.ApplyFilter(query, filter);
            var totalCount = await query.CountAsync();
            var items = await query
                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                        .Take(filter.PageSize)
                        .ProjectTo<EmployeeProfileDTO>(_mapper.ConfigurationProvider)
                        .ToListAsync();

            var dtoItems = _mapper.Map<IEnumerable<EmployeeProfileDTO>>(items);

            return new PagedResult<EmployeeProfileDTO>(dtoItems, totalCount, filter.PageNumber, filter.PageSize);

        }

    }
}
