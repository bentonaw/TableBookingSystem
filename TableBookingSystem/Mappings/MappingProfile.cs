﻿using AutoMapper;
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
            CreateMap<CustomerDTO, CustomerViewModel>();
        }
    }
}
