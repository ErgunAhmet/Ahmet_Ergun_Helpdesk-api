
namespace Helpdesk_api.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? TicketTitle { get; set; }
        public string? TicketDescription { get; set;}
        public int? ResponsibleEmployeeId { get; set; }
        public Employee TicketReceiver { get; set; } = null!;
    }
}
