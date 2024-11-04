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
            CreateMap<CreateReservationDTO, Reservation>()
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore()); // Ignore CustomerId as it will be set manually

            // Map CreateReservationDTO to Customer
            CreateMap<CreateReservationDTO, Customer>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            // Map CreateReservationDTO to Reservation
            CreateMap<CreateReservationDTO, Reservation>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.TimeSlotId, opt => opt.MapFrom(src => src.TimeSlotId))
                .ForMember(dest => dest.NrOfSeats, opt => opt.MapFrom(src => src.NrOfSeats))
                .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.ReservationDate));

            // Map Reservation to GetReservationDTO
            CreateMap<Reservation, GetReservationDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Timeslot.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.Timeslot.EndTime))
                .ForMember(dest => dest.FormattedReservationDate, opt => opt.MapFrom(src => src.ReservationDate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.TableId));

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
