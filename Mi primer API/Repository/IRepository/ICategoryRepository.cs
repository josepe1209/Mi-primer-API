using Mi_primer_API.DAL.Models;

namespace Mi_primer_API.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Me retorna una lista de categorias
        Task<Category> GetCategoryAsync(int id); //Me retorna una categoria por id
        Task<bool> CategoryExistsByIdAsync(int id); //Me retorna true o false si existe la categoria por id
        Task<bool> CategoryExistsByNameAsync(string name); //Me retorna true o false si existe la categoria por nombre
        Task<bool> CreateCategoryAsync(Category category); //Me crea una categoria
        Task<bool> UpdateCategoryAsync(Category category); //Me actualiza una categoria
        Task<bool> DeleteCategoryAsync(int id); //Me elimina una categoria
    }
}
