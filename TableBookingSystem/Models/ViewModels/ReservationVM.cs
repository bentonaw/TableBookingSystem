using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TableBookingSystem.Models.ViewModels
{
	public class ReservationVM
	{
		public int ReservationId { get; set; }
        public ReservationCustomerVM CustomerVM { get; set; }	
		public TimeSlotVM TimeslotVM { get; set; }
		public ICollection<TableReservation> TableReservations { get; set; }
		public int NrOfSeats { get; set; }
		[JsonIgnore]
		public DateTime ReservationDate { get; set; }
		public string FormattedReservationDate => ReservationDate.ToString("yyyy-MM-dd");
	}
}
