using System.ComponentModel.DataAnnotations;

namespace TableBookingSystem.Models
{
	public class Table
	{
        [Key]
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public bool Communal { get; set; }
    }
}
