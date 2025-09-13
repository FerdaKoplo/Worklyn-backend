using AutoMapper;
using Casbin.Persist;
using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Api.DTOs.EmployeeProfile;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Domain.Data;
using Worklyn_backend.Domain.Entities;

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

        public async Task<IEnumerable<EmployeeProfileDTO>> GetAllProfileAsync(EmployeeProfileFilterDTO filter = null)
        {
            var query = _dbContext.EmployeeProfiles
                         .Include(p => p.Employee)
                         .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.FullName))
                {
                    query = query.Where(p =>
                        p.Name.FirstName.Contains(filter.FullName) ||
                        p.Name.LastName.Contains(filter.FullName)
                    );
                }

                if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
                    query = query.Where(p => p.PhoneNumber.Value == filter.PhoneNumber);


                if (!string.IsNullOrWhiteSpace(filter.Email))
                    query = query.Where(p => p.Email.Value == filter.Email);

                if (!string.IsNullOrWhiteSpace(filter.Gender))
                    query = query.Where(p => p.Gender.ToString() == filter.Gender);

                if (!string.IsNullOrWhiteSpace(filter.Religion))
                    query = query.Where(p => p.Religion != null && p.Religion.ToString() == filter.Religion);

                if (!string.IsNullOrWhiteSpace(filter.Province))
                    query = query.Where(p => p.Address.Province == filter.Province);

                if (!string.IsNullOrWhiteSpace(filter.City))
                    query = query.Where(p => p.Address.City == filter.City);

                if (!string.IsNullOrWhiteSpace(filter.BloodType))
                    query = query.Where(p => p.BloodType.ToString()== filter.BloodType);

                if (!string.IsNullOrWhiteSpace(filter.MaritalStatus))
                    query = query.Where(p => p.MaritalStatus.ToString() == filter.MaritalStatus);

                if (!string.IsNullOrWhiteSpace(filter.Nationality))
                    query = query.Where(p => p.Nationality.ToString() == filter.Nationality);

            }

            var profiles = await query.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeProfileDTO>>(profiles);

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

        //public async Task<IEnumerable<EmployeeProfileDTO>> SearchProfilesAsync(EmployeeProfileFilterDTO filter)
        //{
        //    var query = _dbContext.EmployeeProfiles.AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(filter.FullName))
        //        query = query.Where(p => (p.Name.FirstName + " " + p.Name.LastName).Contains(filter.FullName));

        //    if (!string.IsNullOrWhiteSpace(filter.Gender))
        //        query = query.Where(p => p.Gender.ToString() == filter.Gender);

        //    if (!string.IsNullOrWhiteSpace(filter.MaritalStatus))
        //        query = query.Where(p => p.MaritalStatus.ToString() == filter.MaritalStatus);

        //    if (!string.IsNullOrWhiteSpace(filter.Nationality))
        //        query = query.Where(p => p.Nationality.Contains(filter.Nationality));

        //    if (!string.IsNullOrWhiteSpace(filter.Email))
        //        query = query.Where(p => p.Email.Value.Contains(filter.Email));

        //    if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
        //        query = query.Where(p => p.PhoneNumber.Value.Contains(filter.PhoneNumber));

        //    if (!string.IsNullOrWhiteSpace(filter.City))
        //        query = query.Where(p => p.Address.City.Contains(filter.City));

        //    if (!string.IsNullOrWhiteSpace(filter.Province))
        //        query = query.Where(p => p.Address.Province.Contains(filter.Province));

        //    if (!string.IsNullOrWhiteSpace(filter.BloodType))
        //        query = query.Where(p => p.BloodType.ToString() == filter.BloodType);

        //    if (!string.IsNullOrWhiteSpace(filter.Religion))
        //        query = query.Where(p => p.Religion.ToString() == filter.Religion);

        //    var profiles = await query.ToListAsync();
        //    return _mapper.Map<IEnumerable<EmployeeProfileDTO>>(profiles);
        //}
    }
}
