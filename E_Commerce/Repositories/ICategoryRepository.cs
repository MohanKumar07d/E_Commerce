using E_Commerce.Models;

namespace E_Commerce.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category?> UpdateCategoryAsync(int id, Category category);
         
         
         Task<bool?> DeleteCategoryAsync(int id);
    }
}
