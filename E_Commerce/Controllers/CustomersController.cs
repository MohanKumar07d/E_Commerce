using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using E_Commerce.Models;
using E_Commerce.Models.Dto;
using E_Commerce.Repositories;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;

        public CustomersController(IMapper mapper ,ICustomerRepository customerRepository)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] AddCustomerRequestDto customerRequestdto)
        {
            //mapping customerRequestDto to Customer model  
            var customerDomainModel = mapper.Map<Customer>(customerRequestdto);
            await customerRepository.CreateCustomerAsync(customerDomainModel);
            //mapping Customer model to CustomersDto
            var customerDto = mapper.Map<CustomersDto>(customerDomainModel);
            return Ok(customerDto);
        }
    }
}
