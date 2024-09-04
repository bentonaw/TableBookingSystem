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
			CreateMap<CustomerDTO, CustomerViewModel>();
			CreateMap<CustomerViewModel, Customer>();
            CreateMap<CustomerViewModel, CustomerDTO>();
            

			CreateMap<Reservation, ReservationDTO>();
			CreateMap<Reservation, ReservationViewModel>();
			CreateMap<ReservationDTO, Reservation>();
			CreateMap<ReservationDTO, ReservationViewModel>();
			CreateMap<ReservationViewModel, Reservation>();
			CreateMap<ReservationViewModel, ReservationDTO>();
			
			CreateMap<MenuItem, MenuItemDTO>();
			CreateMap<MenuItem, MenuItemViewModel>();
			CreateMap<MenuItemDTO, MenuItem>();
			CreateMap<MenuItemDTO, MenuItemViewModel>();
			CreateMap<MenuItemViewModel, MenuItem>();
			CreateMap<MenuItemViewModel, MenuItemDTO>();
			

		}
    }
}
