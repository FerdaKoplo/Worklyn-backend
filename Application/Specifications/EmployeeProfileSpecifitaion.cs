using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Api.DTOs.Employee;
using Worklyn_backend.Api.DTOs.EmployeeProfile;
using Worklyn_backend.Domain.Entities;
using Worklyn_backend.Domain.Enum.EmployeeProfile;

namespace Worklyn_backend.Application.Specifications
{
    public static class EmployeeProfileSpecifitaion
    {
        public static IQueryable<EmployeeProfile> ApplyFilter(
            IQueryable<EmployeeProfile> query,
            EmployeeProfileFilterDTO? filter)
        {
            if (filter == null) return query;

            if (!string.IsNullOrWhiteSpace(filter.FullName))
            {
                query = query.Where(p =>
                    p.Name.FirstName.Contains(filter.FullName) ||
                    p.Name.LastName.Contains(filter.FullName));
            }

            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
                query = query.Where(p => p.PhoneNumber.Value == filter.PhoneNumber);

            if (!string.IsNullOrWhiteSpace(filter.Email))
                query = query.Where(p => p.Email.Value == filter.Email);

            if (!string.IsNullOrWhiteSpace(filter.Gender) &&
                Enum.TryParse<Gender>(filter.Gender, true, out var gender))
            {
                query = query.Where(p => p.Gender == gender);
            }

            if (!string.IsNullOrWhiteSpace(filter.Religion) &&
                  Enum.TryParse<Religion>(filter.Religion, true, out var religion))
            {
                query = query.Where(p => p.Religion == religion);
            }

            if (!string.IsNullOrWhiteSpace(filter.Province))
                query = query.Where(p => p.Address.Province == filter.Province);

            if (!string.IsNullOrWhiteSpace(filter.City))
                query = query.Where(p => p.Address.City == filter.City);

            if (!string.IsNullOrWhiteSpace(filter.BloodType))
                query = query.Where(p => p.BloodType.ToString() == filter.BloodType);

            if (!string.IsNullOrWhiteSpace(filter.MaritalStatus))
                query = query.Where(p => p.MaritalStatus.ToString() == filter.MaritalStatus);

            if (!string.IsNullOrWhiteSpace(filter.Nationality))
                query = query.Where(p => p.Nationality.ToString() == filter.Nationality);

            return query;
        }
    }
}
