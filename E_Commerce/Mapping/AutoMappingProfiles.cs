using AutoMapper;
using E_Commerce.Models;
using E_Commerce.Models.Dto;
namespace E_Commerce.Mapping
{
    public class AutomappingProfiles : Profile
    {
        public AutomappingProfiles()
        {
            CreateMap<Category,categoryDto>().ReverseMap();
            CreateMap<AddCategoryRequestDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();
            CreateMap<AddCustomerRequestDto,Customer>().ReverseMap();
            CreateMap<Customer, CustomersDto>().ReverseMap();


        }
    }
}
