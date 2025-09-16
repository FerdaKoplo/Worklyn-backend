using Worklyn_backend.Api.DTOs.Department;
using Worklyn_backend.Domain.Entities;

namespace Worklyn_backend.Application.Specifications
{
    public static class DepartmentSpesification
    {
        public static IQueryable<Department> ApplyFilter(
            IQueryable<Department> query,
            DepartmentDTO? filter)
        {

        }
    }
}
