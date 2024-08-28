using Microsoft.EntityFrameworkCore;
using TableBookingSystem.Models;

namespace TableBookingSystem.Data
{
	public class TableBookingSystemContext : DbContext
	{
        public TableBookingSystemContext(DbContextOptions<TableBookingSystemContext> options) : base (options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableReservation> TableReservations { get; set; }
        public DbSet<TimeSlot> TimeSlot { get; set; }
    }
}
