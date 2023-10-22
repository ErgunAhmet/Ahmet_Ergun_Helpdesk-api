
namespace Helpdesk_api.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? JobTitle { get; set; }
        public string? Email { get; set; }
        public IList<Ticket> ReceivedTickets { get; set; } = new List<Ticket>();
    }
}
