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
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Table>().HasData
			(
				new Table { TableId = 1, TableNumber = 1, Capacity = 8, Communal = true },
				new Table { TableId = 2, TableNumber = 2, Capacity = 4, Communal = false },
				new Table { TableId = 3, TableNumber = 3, Capacity = 4, Communal = false },
				new Table { TableId = 4, TableNumber = 4, Capacity = 2, Communal = false },
				new Table { TableId = 5, TableNumber = 5, Capacity = 2, Communal = false },
				new Table { TableId = 6, TableNumber = 6, Capacity = 2, Communal = false }
			);

			modelBuilder.Entity<TimeSlot>().HasData
			(
				
				new TimeSlot { TimeSlotId = 1, StartTime = new TimeSpan(17,00,00) , EndTime = new TimeSpan(19, 00, 00)},
				new TimeSlot { TimeSlotId = 2, StartTime = new TimeSpan(17,30,00) , EndTime = new TimeSpan(19, 30, 00)},
				new TimeSlot { TimeSlotId = 3, StartTime = new TimeSpan(18,00,00) , EndTime = new TimeSpan(20, 00, 00)},
				new TimeSlot { TimeSlotId = 4, StartTime = new TimeSpan(18,30,00) , EndTime = new TimeSpan(20, 30, 00)},
				new TimeSlot { TimeSlotId = 5, StartTime = new TimeSpan(19,00,00) , EndTime = new TimeSpan(21, 00, 00)},
				new TimeSlot { TimeSlotId = 6, StartTime = new TimeSpan(19,30,00) , EndTime = new TimeSpan(21, 30, 00)},
				new TimeSlot { TimeSlotId = 7, StartTime = new TimeSpan(20,00,00) , EndTime = new TimeSpan(22, 00, 00)}
			);
		}
	}
}
