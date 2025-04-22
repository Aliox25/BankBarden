using AutoMapper;
using BankBarden.ViewModels;
using DataAccessLayer.DTOs;

namespace BankBarden.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Från => Till
            CreateMap<AllCustomerDTO, AllCustomersViewModel>()
                .ReverseMap();
        }
    }

}
