using System.ComponentModel.DataAnnotations;

namespace TableBookingSystem.Models
{
	public class Table
	{
        [Key]
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int SeatCount { get; set; }
        public bool Communal { get; set; }
    }
}
