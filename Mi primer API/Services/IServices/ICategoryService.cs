using Mi_primer_API.DAL.Models;
using Mi_primer_API.DAL.Models.Dto;

namespace Mi_primer_API.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id); 
        Task<bool> CategoryExistsByIdAsync(int id); 
        Task<bool> CategoryExistsByNameAsync(string name); 
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryDto); 
        Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto categoryDto, int id); 
        Task<bool> DeleteCategoryAsync(int id);
    }
}
