using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableBookingSystem.Models
{
	public class TimeSlot
	{
        [Key]
        public int TimeSlotId { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }
        [Required]
        public DateTime Date { get; set; }
		[Required]
		public DateTime StartTime { get; set; }
		[Required]
		public DateTime EndTime { get; set; }
    }
}
