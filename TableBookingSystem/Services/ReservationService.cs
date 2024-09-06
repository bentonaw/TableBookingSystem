using AutoMapper;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;
using TableBookingSystem.Services.IService;

namespace TableBookingSystem.Services
{
	public class ReservationService : IReservationService
	{
		private readonly IReservationRepo _repo;
		private readonly IMapper _mapper;
        public ReservationService(IReservationRepo repo, IMapper mapper)
        {
            _repo = repo;
			_mapper = mapper;
        }


		public async Task AddReservationAsync(CreateReservationDTO reservationDTO)
		{
			var newReservation = _mapper.Map<Reservation>(reservationDTO);
			await _repo.AddReservationAsync(newReservation);
		}

		public async Task DeleteReservationAsync(int reservationId)
		{
			var reservation = await _repo.GetReservationByIdAsync(reservationId);
			if (reservation != null)
			{
				_repo.DeleteReservationAsync(reservationId);
			}
		}

		public async Task<ReservationVM> GetReservationByIdAsync(int reservationId)
		{
			var reservation = await _repo.GetReservationByIdAsync(reservationId);
			return reservation != null ? _mapper.Map<ReservationVM>(reservation) : null;
		}

		public async Task<IEnumerable<ReservationVM>> GetReservationsByCustomerLastNameAsync(string lastName)
		{
			var reservationList = await _repo.GetReservationsByCustomerLastNameAsync(lastName);
			return _mapper.Map<IEnumerable<ReservationVM>>(reservationList);
		}

		public async Task<IEnumerable<ReservationVM>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate)
		{
			var reservationList = await _repo.GetReservationsByDateRangeAsync(startDate, endDate);
			return _mapper.Map<IEnumerable<ReservationVM>>(reservationList);
		}
		// Only allows for change of nr of seats
		public async Task UpdateReservationAsync(int reservationId, CreateReservationDTO reservationDTO)
		{
			var reservation = await _repo.GetReservationByIdAsync(reservationId);
			if (!int.IsPositive(reservationDTO.NrOfSeats))
			{
				reservation.NrOfSeats = reservationDTO.NrOfSeats;
			}
		}
	}
}
