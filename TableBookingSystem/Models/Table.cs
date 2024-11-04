using System.ComponentModel.DataAnnotations;

namespace TableBookingSystem.Models
{
	public class Table
	{
        [Key]
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; } // reservation will have to check against this for each check
        public bool IsCommunal { get; set; }

        //public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
