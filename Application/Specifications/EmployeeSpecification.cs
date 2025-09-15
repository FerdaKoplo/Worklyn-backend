using Worklyn_backend.Api.DTOs.Employee;
using Worklyn_backend.Domain.Entities;

namespace Worklyn_backend.Application.Specifications
{
    public static class EmployeeSpecification
    {
        public static IQueryable<Employee> ApplyFilter(
            IQueryable<Employee> query,
            EmployeeFilterDTO? filter)
        {
            if (filter == null) return query;

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(e =>
                    e.Profile.Name.FirstName.Contains(filter.Name) ||
                    e.Profile.Name.LastName.Contains(filter.Name));
            }

            if (filter.DepartmentId.HasValue)
                query = query.Where(e => e.DepartmentId == filter.DepartmentId.Value);

            if (filter.PositionId.HasValue)
                query = query.Where(e => e.PositionId == filter.PositionId.Value);

            if (!string.IsNullOrWhiteSpace(filter.Status))
                query = query.Where(e => e.Status.ToString() == filter.Status);

            return query;
        }
    }
}
