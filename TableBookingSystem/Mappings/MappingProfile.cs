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
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<CreateCustomerDTO, CustomerViewModel>();
        }
    }
}
