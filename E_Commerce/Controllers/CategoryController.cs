using AutoMapper;
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Models.Dto;
using E_Commerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ECommerceContext dbContext;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ECommerceContext dbContext,ICategoryRepository categoryRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categoriesDomain = await categoryRepository.GetCategoriesAsync();
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
            //var categorysDto = new List<categoryDto>();
            //foreach (var categoriesDomains in categoriesDomain)
            //{
            //    categorysDto.Add(new categoryDto()
            //    {
            //        CategoryId = categoriesDomains.CategoryId,
            //        CategoryName = categoriesDomains.CategoryName
            //    });
            //}
            var categorysDto = mapper.Map<List<categoryDto>>(categoriesDomain);
            return Ok(categorysDto);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryByid(int id)
        {
            // var categorybyid = dbContext.Categories.Find(id);
            // var categorybyid = dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            var categoriesDomain = await categoryRepository.GetCategoryByIdAsync(id);
            if (categoriesDomain == null)
            {
                return NotFound();
            }
            //var categorysDto = new categoryDto
            //{
            //    CategoryId = categoriesDomain.CategoryId,
            //    CategoryName = categoriesDomain.CategoryName
            //};
            var categorysDto = mapper.Map<categoryDto>(categoriesDomain);
            return Ok(categoriesDomain);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCategoryRequestDto addCategoryRequestDto)
        {
            //var categoriesDomainModel = new Category
            //{
            //    CategoryId = addCategoryRequestDto.CategoryId,
            //    CategoryName = addCategoryRequestDto.CategoryName
            //};
            var categoriesDomainModel = mapper.Map<Category>(addCategoryRequestDto);
            categoriesDomainModel =await categoryRepository.CreateCategoryAsync(categoriesDomainModel);
            //await dbContext.SaveChangesAsync();
            //var categorysDto = new categoryDto
            //{
            //    CategoryId = categoriesDomainModel.CategoryId,
            //    CategoryName = categoriesDomainModel.CategoryName
            //};
            var categorysDto = mapper.Map<categoryDto>(categoriesDomainModel);
            return CreatedAtAction(nameof(GetCategoryByid), new { id = categorysDto.CategoryId }, categorysDto);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            
            var categoriesDomainModel =mapper.Map<Category>(updateCategoryRequestDto);
            categoriesDomainModel = await categoryRepository.UpdateCategoryAsync(id, categoriesDomainModel);

            if (categoriesDomainModel == null)
            {
                return NotFound();
            }
           /* categoriesDomainModel.CategoryName = updateCategoryRequestDto.CategoryName;
            await dbContext.SaveChangesAsync();*/
            var categorysDto = mapper.Map<categoryDto>(categoriesDomainModel);  
            return Ok(categorysDto);
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var categoriesDomainModel = await categoryRepository.GetCategoryByIdAsync(id);
            if (categoriesDomainModel == null)
            {
                return NotFound();
            }
          // dbContext.Categories.Remove(categoriesDomainModel);
            // dbContext.Categories.Remove(categoriesDomainModel);
            //await dbContext.SaveChangesAsync();
            //var categorysDto = new categoryDto
            //{
            //    CategoryId = categoriesDomainModel.CategoryId,
            //    CategoryName = categoriesDomainModel.CategoryName
            //};
            return Ok(mapper.Map<categoryDto>(categoriesDomainModel));
        }
    }
}
