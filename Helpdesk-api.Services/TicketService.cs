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
    public class TicketService
    {
        private readonly HelpDeskDbContext _dbContext;

        public TicketService(HelpDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<TicketResult>> GetAllTicketsAsync()
        {
            return await _dbContext.Tickets
                .ProjectToResults()
                .ToListAsync();
        }

        public async Task<TicketResult?> GetTicketByIdAsync(int ticketId)
        {
            return await _dbContext.Tickets
                .ProjectToResults()
                .FirstOrDefaultAsync(t => t.Id == ticketId);
        }

        public async Task<ServiceResult<TicketResult?>> CreateTicketAsync(TicketCreateRequest request)
        {
            // Create the ticket
            var ticket = new Ticket
            {
                TicketTitle = request.TicketTitle,
                TicketDescription = request.TicketDescription,
            };

            // Check if an employee ID is provided for assignment
            if (request.EmployeeId.HasValue)
            {
                var employee = await _dbContext.Employees.FindAsync(request.EmployeeId);
                if (employee == null)
                {
                    throw new NotFoundException("Employee not found");
                }
                ticket.ResponsibleEmployeeId = employee.Id;
            }

            _dbContext.Tickets.Add(ticket);
            await _dbContext.SaveChangesAsync();

            var ticketResult = await GetTicketByIdAsync(ticket.Id);
            return new ServiceResult<TicketResult?>(ticketResult);
        }

        public async Task<ServiceResult<TicketResult?>> UpdateTicketAsync(int ticketId, TicketUpdateRequest request)
        {
            var ticket = await _dbContext.Tickets.FindAsync(ticketId);
            if (ticket == null)
                throw new NotFoundException("Ticket not found");

            ticket.TicketTitle = request.TicketTitle;
            ticket.TicketDescription = request.TicketDescription;
            ticket.ResponsibleEmployeeId = request.ResponsibleEmployeeId;

            await _dbContext.SaveChangesAsync();

            var ticketResult = await GetTicketByIdAsync(ticketId);
            return new ServiceResult<TicketResult?>(ticketResult);
        }

        public async Task<ServiceResult> DeleteTicketAsync(int ticketId)
        {
            var ticket = await _dbContext.Tickets.FindAsync(ticketId);
            if (ticket == null)
                return new ServiceResult().NotFound("vehicle");

            _dbContext.Tickets.Remove(ticket);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult();
        }

        public async Task<ServiceResult> UpdateTicketStatusAsync(int ticketId, TicketStatus status)
        {
            var ticket = await _dbContext.Tickets.FindAsync(ticketId);
            if (ticket == null)
                return new ServiceResult().NotFound("Ticket");
            ticket.Status = status;
            await _dbContext.SaveChangesAsync();

            return new ServiceResult();
        }
    }
}
