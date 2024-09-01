using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableBookingSystem.Models
{
	public class TimeSlot
	{
        [Key]
        public int TimeSlotId { get; set; }
		[Required]
		public TimeSpan StartTime { get; set; }
		[Required]
		public TimeSpan EndTime { get; set; }
    }
}
