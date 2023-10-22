using Helpdesk_api.Dto;
using Helpdesk_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Services.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<EmployeeResult> ProjectToResults(this IQueryable<Employee> query)
        {
            return query.Select(e => new EmployeeResult
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                JobTitle = e.JobTitle,
                Email = e.Email
            });
        }

        public static IQueryable<TicketResult> ProjectToResults(this IQueryable<Ticket> query)
        {
            return query.Select(t => new TicketResult
            {
                Id = t.Id,
                TicketTitle = t.TicketTitle,
                TicketDescription = t.TicketDescription,
                ResponsibleEmployeeId = t.ResponsibleEmployeeId
            });
        }
    }
}
