using Worklyn_backend.Domain.Enum.Payroll;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Worklyn_backend.Domain.Entities
{
    public class Payroll : BaseEntity
    {
        public int PayrollID { get; set; }

        // Tenant awareness
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        // Employee link
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        // Pay period
        public DateTime PayPeriodStart { get; set; }
        public DateTime PayPeriodEnd { get; set; }

        // Salary breakdown
        public decimal BasicSalary { get; set; }
        public decimal Overtime { get; set; }
        public decimal Allowances { get; set; }
        public decimal Bonuses { get; set; }
        public decimal Deductions { get; set; }
        public decimal BPJSContribution { get; set; }
        public decimal TaxDeduction { get; set; }

        // Final calculated net pay
        public decimal NetPay { get; set; }

        // Status of payroll
        public PayrollStatus Status { get; set; } = PayrollStatus.Draft;

    }
}
