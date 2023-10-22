 using Helpdesk_api.Model;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk_api.Core
{
    public class HelpDeskDbContext: DbContext
    {
        public HelpDeskDbContext(DbContextOptions<HelpDeskDbContext> options) : base (options)
        { }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(v => v.TicketReceiver)
                .WithMany(p => p.ReceivedTickets)
                .HasForeignKey(v => v.ResponsibleEmployeeId)
                .IsRequired(false);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
