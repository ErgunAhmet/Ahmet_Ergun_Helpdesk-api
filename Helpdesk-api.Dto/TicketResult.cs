using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Dto
{
    public class TicketResult
    {
        public int Id { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }
        public int? ResponsibleEmployeeId { get; set; }
        public string? Status { get; set; }
    }
}
