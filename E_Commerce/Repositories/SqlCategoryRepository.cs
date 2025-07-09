using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private readonly ECommerceContext dbContext;

        public SqlCategoryRepository(ECommerceContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            
                await dbContext.SaveChangesAsync();
                return category;
           
        }

        public async Task<bool?> DeleteCategoryAsync(int id)
        {
            var categoriesDomainModel = await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (categoriesDomainModel == null)
            {
                return null;
            }
            dbContext.Categories.Remove(categoriesDomainModel);
            await dbContext.SaveChangesAsync();
            return categoriesDomainModel != null;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
           return await dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);


        }

        public async Task<Category?> UpdateCategoryAsync(int id, Category category)
        {
            var categoriesDomainModel = await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (categoriesDomainModel == null)
            {
                return null;
            }
            categoriesDomainModel.CategoryName = category.CategoryName;
            await dbContext.SaveChangesAsync();
            return categoriesDomainModel;
        }
    }
}
