using E_Commerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Models.Dto;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ECommerceContext dbContext;

        public CategoryController(ECommerceContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categoriesDomain = dbContext.Categories.ToList();
            /* var categoryNames = dbContext.Categories.Select(c => new 
             {
                 c.CategoryId,
                 c.CategoryName
             }).ToList();
             return Ok(categoryNames);*/
            /*  var categoriesDto = categoriesDomain.Select(c => new 
               {
                   c.CategoryId,
                   c.CategoryName
               }).ToList();
               return Ok(categoriesDto);*/
            var categorysDto = new List<categoryDto>();
            foreach (var categoriesDomains in categoriesDomain)
            {
              categorysDto.Add(new categoryDto()
              {
                  CategoryId = categoriesDomains.CategoryId,
                  CategoryName = categoriesDomains.CategoryName
              });
            }
            return Ok(categorysDto);

        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategoryByid(int id) 
        {
            // var categorybyid = dbContext.Categories.Find(id);
            // var categorybyid = dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            var categoriesDomain = dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (categoriesDomain == null)
            {
                return NotFound();
            }
            var categorysDto = new categoryDto
            {
                CategoryId = categoriesDomain.CategoryId,
                CategoryName = categoriesDomain.CategoryName
            };
            return Ok(categoriesDomain);

        }
    }
}
