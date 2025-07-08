using E_Commerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var categories = dbContext.Categories.ToList();
            return Ok(categories);
        }
    }
}
