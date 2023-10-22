using Helpdesk_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Dto
{
    public class EmployeeUpdateTicketStatusRequest
    {
        public int TicketId { get; set; }
        public TicketStatus Status { get; set; }
    }
}
