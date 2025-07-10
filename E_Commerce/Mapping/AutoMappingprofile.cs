using AutoMapper;
using E_Commerce.Models;
using E_Commerce.Models.Dto;
using System.Runtime;

namespace E_Commerce.Mapping
{
    public class AutoMappingprofile:Profile
    {

        public AutoMappingprofile()
        {
            CreateMap<Category, categoryDto>().ReverseMap();
        }
    }
}
