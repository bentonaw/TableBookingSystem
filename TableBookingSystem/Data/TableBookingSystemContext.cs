using Microsoft.EntityFrameworkCore;
using TableBookingSystem.Models;

namespace TableBookingSystem.Data
{
    public class TableBookingSystemContext : DbContext
    {
        public TableBookingSystemContext(DbContextOptions<TableBookingSystemContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Table>().HasData
            (
                new Table { TableId = 1, TableNumber = 1, Capacity = 8, IsCommunal = true },
                new Table { TableId = 2, TableNumber = 2, Capacity = 4, IsCommunal = false },
                new Table { TableId = 3, TableNumber = 3, Capacity = 4, IsCommunal = false },
                new Table { TableId = 4, TableNumber = 4, Capacity = 2, IsCommunal = false },
                new Table { TableId = 5, TableNumber = 5, Capacity = 2, IsCommunal = false },
                new Table { TableId = 6, TableNumber = 6, Capacity = 2, IsCommunal = false }
            );

            modelBuilder.Entity<TimeSlot>().HasData
            (
                new TimeSlot { TimeSlotId = 1, StartTime = new TimeSpan(12, 00, 00), EndTime = new TimeSpan(13, 15, 00) },
                new TimeSlot { TimeSlotId = 2, StartTime = new TimeSpan(12, 30, 00), EndTime = new TimeSpan(13, 45, 00) },
                new TimeSlot { TimeSlotId = 3, StartTime = new TimeSpan(13, 00, 00), EndTime = new TimeSpan(14, 15, 00) },
                new TimeSlot { TimeSlotId = 4, StartTime = new TimeSpan(13, 30, 00), EndTime = new TimeSpan(14, 45, 00) },
                new TimeSlot { TimeSlotId = 5, StartTime = new TimeSpan(14, 00, 00), EndTime = new TimeSpan(15, 15, 00) },
                new TimeSlot { TimeSlotId = 6, StartTime = new TimeSpan(14, 30, 00), EndTime = new TimeSpan(15, 45, 00) },
                new TimeSlot { TimeSlotId = 7, StartTime = new TimeSpan(15, 00, 00), EndTime = new TimeSpan(16, 00, 00) },
                new TimeSlot { TimeSlotId = 8, StartTime = new TimeSpan(18, 00, 00), EndTime = new TimeSpan(20, 00, 00) },
                new TimeSlot { TimeSlotId = 9, StartTime = new TimeSpan(18, 30, 00), EndTime = new TimeSpan(20, 30, 00) },
                new TimeSlot { TimeSlotId = 10, StartTime = new TimeSpan(19, 00, 00), EndTime = new TimeSpan(21, 00, 00) },
                new TimeSlot { TimeSlotId = 11, StartTime = new TimeSpan(19, 30, 00), EndTime = new TimeSpan(21, 30, 00) },
                new TimeSlot { TimeSlotId = 12, StartTime = new TimeSpan(20, 00, 00), EndTime = new TimeSpan(22, 00, 00) },
                new TimeSlot { TimeSlotId = 13, StartTime = new TimeSpan(20, 30, 00), EndTime = new TimeSpan(22, 30, 00) },
                new TimeSlot { TimeSlotId = 14, StartTime = new TimeSpan(21, 00, 00), EndTime = new TimeSpan(22, 30, 00) }
            );

            modelBuilder.Entity<MenuItem>().HasData
            (
                new MenuItem { MenuItemId = 1, MenuItemName = "Burger", MenuItemCategory = "Main Course", MenuDescription = "Original burger made from ...", Price = 9.99, Quantity = 10 },
                new MenuItem { MenuItemId = 2, MenuItemName = "Pizza", MenuItemCategory = "Main Course", MenuDescription = "cheese and tomato sauce", Price = 12.99, Quantity = 10 },
                new MenuItem { MenuItemId = 3, MenuItemName = "Salad", MenuItemCategory = "Appetizer", MenuDescription = "lorem", Price = 6.99, Quantity = 10 },
                new MenuItem { MenuItemId = 4, MenuItemName = "Pasta", MenuItemCategory = "Main Course", MenuDescription = "ipsum", Price = 11.99, Quantity = 10 },
                new MenuItem { MenuItemId = 5, MenuItemName = "Soup", MenuItemCategory = "Appetizer", MenuDescription = "lorem ipsum", Price = 4.99, Quantity = 10 },
                new MenuItem { MenuItemId = 6, MenuItemName = "Steak", MenuItemCategory = "Main Course", MenuDescription = "test", Price = 15.99, Quantity = 10 },
                new MenuItem { MenuItemId = 7, MenuItemName = "Fish and Chips", MenuItemCategory = "Main Course", MenuDescription = "test", Price = 13.99, Quantity = 10 },
                new MenuItem { MenuItemId = 8, MenuItemName = "Sushi", MenuItemCategory = "Main Course", MenuDescription = "test", Price = 16.99, Quantity = 10 },
                new MenuItem { MenuItemId = 9, MenuItemName = "Nachos", MenuItemCategory = "Appetizer", MenuDescription = "test", Price = 8.99, Quantity = 10 },
                new MenuItem { MenuItemId = 10, MenuItemName = "Ice Cream", MenuItemCategory = "Dessert", MenuDescription = "test", Price = 5.99, Quantity = 10 }
            );

            modelBuilder.Entity<Menu>().HasData
            (
                new Menu { MenuId = 1, MenuName = "W.42" },
                new Menu { MenuId = 2, MenuName = "W.43" }
            );
        }
    }
}
