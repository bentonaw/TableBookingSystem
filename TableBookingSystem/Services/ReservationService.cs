using AutoMapper;
using TableBookingSystem.Data.Repo;
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
        private readonly ICustomerRepo _customerRepo;
        public ReservationService(IReservationRepo repo, IMapper mapper, ITableReservationRepo tableReservationRepo, ICustomerRepo customerRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _tableRepo = tableReservationRepo;
            _customerRepo = customerRepo;
        }


        //public async Task AddReservationAsync(CreateReservationDTO reservationDTO)
        //{
        //    var newReservation = _mapper.Map<Reservation>(reservationDTO);
        //    await _repo.AddReservationAsync(newReservation);
        //}

        public async Task AddReservationAsync(CreateReservationDTO reservationDTO)
        {
            // Check if the customer already exists
            var existingCustomer = await _customerRepo.GetCustomerByEmailAsync(reservationDTO.Email);

            int customerId;

            if (existingCustomer == null)
            {
                // Create a new customer
                var newCustomer = _mapper.Map<Customer>(reservationDTO);
                await _customerRepo.AddCustomersAsync(newCustomer);
                customerId = newCustomer.CustomerId;
            }
            else
            {
                customerId = existingCustomer.CustomerId;
            }

            // Find the first available table
            var tables = await _tableRepo.GetAllTables();
            var availableTable = await FindFirstAvailableTableAsync(tables, reservationDTO.ReservationDate, reservationDTO.TimeSlotId, reservationDTO.NrOfSeats);

            if (availableTable == null)
            {
                throw new Exception("No available table found.");
            }

            // Create the reservation
            var reservation = _mapper.Map<Reservation>(reservationDTO);
            reservation.CustomerId = customerId;
            reservation.TableId = availableTable.TableId;


            await _repo.AddReservationAsync(reservation);
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

        public async Task<IEnumerable<GetTimeSlotDTO>> GetTimeSlotAsync(DateTime date, int partySize)
        {
            // Fetch all time slots
            var allTimeSlots = await _repo.GetTimeSlotAsync();

            // List to hold available time slots
            var availableTimeSlots = new List<TimeSlot>();

            // Check each time slot for table availability
            foreach (var timeSlot in allTimeSlots)
            {
                // Fetch all tables
                var allTables = await _tableRepo.GetAllTables();

                // Check if any table is available for the given date, time slot, and party size
                bool isAvailable = allTables.Any(table => IsTableAvailable(table.TableId, date, timeSlot.TimeSlotId, partySize).Result);

                if (isAvailable)
                {
                    availableTimeSlots.Add(timeSlot);
                }
            }

            // Map the available time slots to DTOs
            return _mapper.Map<IEnumerable<GetTimeSlotDTO>>(availableTimeSlots);
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
            Table? firstSuitableTable = null;

            foreach (var table in tables)
            {
                if (table.Capacity >= requiredSeats)
                {
                    var reservations = await _repo.GetReservationsForTableAsync(table.TableId, date, timeslotId);

                    // Check if the table has no reservations
                    if (!reservations.Any())
                    {
                        return table;
                    }

                    // Store the first suitable table if it's not available
                    if (firstSuitableTable == null)
                    {
                        firstSuitableTable = table;
                    }
                }
            }
            // If no available table is found, return the first suitable one
            return firstSuitableTable;
        }

    }
}
