using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Api.DTOs.Attendance;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Domain.Data;
using AutoMapper.QueryableExtensions;

namespace Worklyn_backend.Application.Services.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AttendanceService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAllAttendanceAsync()
        {
            return await _appDbContext.Attendances
              .Include(a => a.Employee).ThenInclude(e => e.Profile)
              .ProjectTo<AttendanceDTO>(_mapper.ConfigurationProvider)
              .ToListAsync();
        }
    }
}
