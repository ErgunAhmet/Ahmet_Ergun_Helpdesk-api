using Helpdesk_api.Core;
using Helpdesk_api.Dto;
using Helpdesk_api.Model;
using Helpdesk_api.Services.Extensions;
using Helpdesk_api.Services.Model;
using Helpdesk_api.Services.Model.Extensions;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Services
{
    public class EmployeeService
    {
        private readonly HelpDeskDbContext _dbContext;

        public EmployeeService(HelpDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<EmployeeResult>> GetAllEmployeesAsync()
        {
            return await _dbContext.Employees
                .ProjectToResults()
                .ToListAsync();
        }

        public async Task<EmployeeResult?> GetEmployeeByIdAsync(int employeeId)
        {
            return await _dbContext.Employees
                .ProjectToResults()
                .FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<ServiceResult<EmployeeResult?>> CreateEmployeeAsync(EmployeeCreateRequest request)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                JobTitle = request.JobTitle,
                Email = request.Email
            };

            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();

            var employeeResult = await GetEmployeeByIdAsync(employee.Id);
            return new ServiceResult<EmployeeResult?>(employeeResult);
        }

        public async Task<ServiceResult<EmployeeResult?>> UpdateEmployeeAsync(int employeeId, EmployeeUpdateRequest request)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            if (employee == null)
                return new ServiceResult<EmployeeResult?>().NotFound("person");

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.JobTitle = request.JobTitle;
            employee.Email = request.Email;

            await _dbContext.SaveChangesAsync();

            var employeeResult = await GetEmployeeByIdAsync(employeeId);
            return new ServiceResult<EmployeeResult?>(employeeResult);
        }

        public async Task<ServiceResult> DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            if (employee == null)
                return new ServiceResult().NotFound("employee");

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult();
        }

        public async Task<ServiceResult> DeleteResolvedTicketsAsync(int employeeId)
        {
            var resolvedTickets = await _dbContext.Tickets
                .Where(t => t.ResponsibleEmployeeId == employeeId && t.Status == TicketStatus.Resolved)
                .ToListAsync();

            if (resolvedTickets.Count == 0)
                return new ServiceResult().NotFound("Resolved Tickets");

            _dbContext.Tickets.RemoveRange(resolvedTickets);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult();
        }
    }
}
