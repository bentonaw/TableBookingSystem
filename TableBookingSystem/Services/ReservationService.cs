using AutoMapper;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Services.IService;

namespace TableBookingSystem.Services
{
    public class ReservationService : IReservationService
	{
		private readonly IReservationRepo _repo;
		private readonly ITableReservationRepo _tableRepo;
		private readonly IMapper _mapper;
        public ReservationService(IReservationRepo repo, IMapper mapper, ITableReservationRepo tableReservationRepo)
        {
            _repo = repo;
			_mapper = mapper;
			_tableRepo = tableReservationRepo;
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
				await _repo.DeleteReservationAsync(reservationId);
			}
		}

        public async Task<GetReservationDTO?> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _repo.GetReservationByIdAsync(reservationId);
            return reservation != null ? _mapper.Map<GetReservationDTO>(reservation) : null;
        }

		public async Task<IEnumerable<GetReservationDTO>> GetReservationsByCustomerLastNameAsync(string lastName)
		{
			var reservationList = await _repo.GetReservationsByCustomerLastNameAsync(lastName);
			return _mapper.Map<IEnumerable<GetReservationDTO>>(reservationList);
		}

		public async Task<IEnumerable<GetReservationDTO>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate)
		{
			var reservationList = await _repo.GetReservationsByDateRangeAsync(startDate, endDate);
			return _mapper.Map<IEnumerable<GetReservationDTO>>(reservationList);
		}

        public async Task<IEnumerable<GetTimeSlotDTO>> GetTimeSlotAsync()
        {
			var timeslotList = await _repo.GetTimeSlotAsync();
			return _mapper.Map<IEnumerable<GetTimeSlotDTO>>(timeslotList);
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

        public async Task<Reservation> AssignTableAsync(int customerId, int timeslotId, int seats, DateTime date)
        {
            var tables = await _tableRepo.GetAllTables();

            // If single person, prioritize communal table
            if (seats == 1)
            {
                
                var availableCommunalTable = await FindFirstAvailableTableAsync(tables.Where(t => t.IsCommunal), date, timeslotId, seats);
                if (availableCommunalTable != null)
                {
                    return await CreateAndAddReservationAsync(customerId, availableCommunalTable.TableId, seats, date, timeslotId);
                }
            }

            // Find the smallest available table that fits the party
            var suitableTables = tables
                .Where(t => t.Capacity >= seats && !t.IsCommunal)
                .OrderBy(t => t.Capacity);

            foreach (var table in suitableTables)
            {
                if (await IsTableAvailable(table.TableId, date, timeslotId, seats))
                {
                    return await CreateAndAddReservationAsync(customerId, table.TableId, seats, date, timeslotId);
                }
            }

            throw new Exception("No available table for the requested party size and timeslot.");
        }



        private async Task<bool> IsTableAvailable(int tableId, DateTime date, int timeslotId, int requiredSeats)
        {
            var reservations = await _repo.GetReservationsForTableAsync(tableId, date, timeslotId);
            var table = await _tableRepo.GetTableByIdAsync(tableId);

            int totalCapacity = table.Capacity;
            int reservedSeats = reservations.Sum(r => r.NrOfSeats);
            int remainingSeats = totalCapacity - reservedSeats;

            return remainingSeats >= requiredSeats;
        }

        private async Task<Reservation> CreateAndAddReservationAsync(int customerId, int tableId, int seats, DateTime date, int timeslotId)
        {
            // Create the DTO based on the provided parameters
            var reservationDTO = new CreateReservationDTO
            {
                CustomerId = customerId,
                TableId = tableId,
                NrOfSeats = seats,
                ReservationDate = date,
                TimeSlotId = timeslotId
            };

            // Use AddReservationAsync to add the reservation using the DTO
            await AddReservationAsync(reservationDTO);

            // Optional: You might want to return the created Reservation object or its ID
            return _mapper.Map<Reservation>(reservationDTO);
        }
        private async Task<Table?> FindFirstAvailableTableAsync(IEnumerable<Table> tables, DateTime date, int timeslotId, int requiredSeats)
        {
            foreach (var table in tables)
            {
                if (await IsTableAvailable(table.TableId, date, timeslotId, requiredSeats))
                {
                    return table;
                }
            }
            return null;
        }

    }
}
