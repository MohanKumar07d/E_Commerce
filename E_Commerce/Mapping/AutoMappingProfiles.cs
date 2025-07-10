using AutoMapper;
using E_Commerce.Models.Dto;
using E_Commerce.Models;

namespace E_Commerce.Mapping
{
    public class AutoMappingProfiles:Profile
    {
        public AutoMappingProfiles()
        {
           CreateMap<Category, categoryDto>().ReverseMap();

        }
    }
}
