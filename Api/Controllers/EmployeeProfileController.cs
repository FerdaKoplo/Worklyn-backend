using Microsoft.AspNetCore.Mvc;
using Worklyn_backend.Api.DTOs.EmployeeProfile;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Application.Services.EmployeeService;

namespace Worklyn_backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeProfileController : ControllerBase
    {
        private readonly IEmployeeProfileService _employeeProfileService;
        public EmployeeProfileController(IEmployeeProfileService employeeProfileService)
        {
            _employeeProfileService = employeeProfileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var profiles = await _employeeProfileService.GetAllProfileAsync();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileById(int id)
        {
            var profile = await _employeeProfileService.GetProfileByIdAsync(id);
            return Ok(profile);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetProfileByEmployeeId(Guid employeeId)
        {
            var profile = await _employeeProfileService.GetProfileByEmployeeIdAsync(employeeId);
            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] CreateEmployeeProfileDTO dto)
        {
            var profile = await _employeeProfileService.CreateProfileAsync(dto);
            return CreatedAtAction(nameof(GetProfileById), new { id = profile.EmployeeProfileId }, profile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] UpdateEmployeeProfileDTO dto)
        {
            var profile = await _employeeProfileService.UpdateProfileAsync(id, dto);
            return Ok(profile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            await _employeeProfileService.DeleteProfileAsync(id);
            return NoContent();
        }
    }
}
