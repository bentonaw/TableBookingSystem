using AutoMapper;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;
using TableBookingSystem.Services.IService;

namespace TableBookingSystem.Services
{
	public class TableReservationService : ITableReservationService
	{
		private readonly ITableReservationService _repo;
		private readonly IMapper _mapper;
		public TableReservationService(ITableReservationService repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

        public Task<IEnumerable<DateTime>> GetUnavailableDates(int nrOfSeats)
        {
            throw new NotImplementedException();
        }

        public Task CreateTableReservations(int nrOfSeats, DateTime date, int timeslotId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Table>> GetAvailableTablesForTimeSlot(int nrOfSeats, DateTime date, int timeslotId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TimeSlot>> GetAvailableTimeSlotsForDate(int nrOfSeats, DateTime date)
        {
            throw new NotImplementedException();
        }


    }
}
