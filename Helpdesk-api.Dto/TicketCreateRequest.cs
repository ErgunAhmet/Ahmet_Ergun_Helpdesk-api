using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Dto
{
    public class TicketCreateRequest
    {
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }
        public int? EmployeeId { get; set; }
    }
}
