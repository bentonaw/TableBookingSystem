using AutoMapper;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Mappings
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Customer, CreateCustomerDTO>();
			CreateMap<Customer, GetCustomerDTO>();
			CreateMap<CreateCustomerDTO, Customer>();
			CreateMap<GetCustomerDTO, Customer>();
			CreateMap<CreateCustomerDTO, GetCustomerDTO>();
			CreateMap<CreateReservationDTO, Reservation>();
			CreateMap<Reservation, GetReservationDTO>()
				.ForMember(c => c.Customer, opt => opt.MapFrom(src => src.Customer))
				.ForPath(ts => ts.TimeSlot, opt => opt.MapFrom(src => src.Timeslot))
				.ForPath(ts => ts.TimeSlot.TimeSlotId, opt => opt.MapFrom(src => src.Timeslot.TimeSlotId))
				.ForPath(ts => ts.TimeSlot.StartTime, opt => opt.MapFrom(src => src.Timeslot.StartTime.ToString(@"hh\:mm")))
				.ForPath(ts => ts.TimeSlot.EndTime, opt => opt.MapFrom(src => src.Timeslot.EndTime.ToString(@"hh\:mm")))
				.ForMember(dest => dest.FormattedReservationDate, opt => opt.MapFrom(src => src.ReservationDate.ToString("yyyy-MM-dd")));
			CreateMap<TimeSlot, GetTimeSlotDTO>()
			   .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString(@"hh\:mm")))
			   .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString(@"hh\:mm")));
			CreateMap<GetTimeSlotDTO, TimeSlot>();
			CreateMap<CreateMenuItemDTO, MenuItem>();
			CreateMap<MenuItem, CreateMenuItemDTO>();
			CreateMap<MenuItem, GetMenuItemDTO>();
			CreateMap<GetMenuItemDTO, MenuItem>();
		}
	}
}
