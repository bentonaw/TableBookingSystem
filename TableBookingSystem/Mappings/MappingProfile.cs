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
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<CustomerViewModel, CustomerDTO>();
            CreateMap<CustomerDTO, CustomerViewModel>();

			CreateMap<Reservation, ReservationDTO>();
			CreateMap<Reservation, ReservationViewModel>();
			CreateMap<ReservationDTO, Reservation>();
			CreateMap<ReservationViewModel, Reservation>();
			CreateMap<ReservationViewModel, ReservationDTO>();
			CreateMap<ReservationDTO, ReservationViewModel>();

		}
    }
}
