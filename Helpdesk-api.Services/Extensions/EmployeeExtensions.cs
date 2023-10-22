using Helpdesk_api.Dto;
using Helpdesk_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Services.Extensions
{
    public static class EmployeeExtensions
    {
        public static EmployeeResult ToResult(this Employee employee)
        {
            return new EmployeeResult
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JobTitle = employee.JobTitle,
                Email = employee.Email
            };
        }
        public static Employee ToEntity(this EmployeeCreateRequest request)
        {
            return new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                JobTitle = request.JobTitle,
                Email = request.Email
            };
        }

        public static void UpdateFromRequest(this Employee employee, EmployeeUpdateRequest request)
        {
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.JobTitle = request.JobTitle;
            employee.Email = request.Email;
        }
    }
}
