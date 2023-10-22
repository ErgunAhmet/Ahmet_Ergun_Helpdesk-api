using Helpdesk_api.Dto;
using Helpdesk_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Services.Extensions
{
    public static class TicketExtensions
    {
        public static TicketResult ToResult(this Ticket ticket)
        {
            return new TicketResult
            {
                Id = ticket.Id,
                TicketTitle = ticket.TicketTitle,
                TicketDescription = ticket.TicketDescription,
                ResponsibleEmployeeId = ticket.ResponsibleEmployeeId
            };
        }

        //public static Ticket ToEntity(this TicketCreateRequest request)
        //{
        //    return new Ticket
        //    {
        //        TicketTitle = request.TicketTitle,
        //        TicketDescription = request.TicketDescription
        //    };
        //}

        //public static void UpdateFromRequest(this Ticket ticket, TicketUpdateRequest request)
        //{
        //    ticket.TicketTitle = request.TicketTitle;
        //    ticket.TicketDescription = request.TicketDescription;
        //    ticket.ResponsibleEmployeeId = request.EmployeeId;
        //}
    }
}
