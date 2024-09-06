using AutoMapper;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;

namespace TableBookingSystem.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Customer, CreateCustomerDTO>();
			CreateMap<Customer, CustomerVM>();
			CreateMap<CreateCustomerDTO, Customer>();
			CreateMap<CustomerVM, Customer>();
			CreateMap<CreateCustomerDTO, CustomerVM>();
			CreateMap<CreateReservationDTO, Reservation>();
			CreateMap<Reservation, ReservationVM>()
				.ForMember(c => c.CustomerVM, opt => opt.MapFrom(src => src.Customer))
				.ForPath(ts => ts.TimeslotVM, opt => opt.MapFrom(src => src.Timeslot))
				.ForPath(ts => ts.TimeslotVM.TimeSlotId, opt => opt.MapFrom(src => src.Timeslot.TimeSlotId))
				.ForPath(ts => ts.TimeslotVM.StartTime, opt => opt.MapFrom(src => src.Timeslot.StartTime.ToString(@"hh\:mm")))
				.ForPath(ts => ts.TimeslotVM.EndTime, opt => opt.MapFrom(src => src.Timeslot.EndTime.ToString(@"hh\:mm")))
				.ForMember(dest => dest.FormattedReservationDate, opt => opt.MapFrom(src => src.ReservationDate.ToString("yyyy-MM-dd")));
			CreateMap<Customer, ReservationCustomerVM>();
			CreateMap<TimeSlot, TimeSlotVM>()
			   .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString(@"hh\:mm")))
			   .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString(@"hh\:mm")));
		}
	}
}
