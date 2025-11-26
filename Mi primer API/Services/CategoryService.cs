using AutoMapper;
using Mi_primer_API.DAL.Models;
using Mi_primer_API.DAL.Models.Dto;
using Mi_primer_API.Repository.IRepository;
using Mi_primer_API.Services.IServices;

namespace Mi_primer_API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;   
        }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateDto)
        {
            //Validar si la categoria ya existe
            var categoryExist = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name);
            if (categoryExist)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{categoryCreateDto.Name}' "); //La categoria ya existe
            }

            //Mapear el DTO a la entidad Category
            var category = _mapper.Map<Category>(categoryCreateDto);

            //Crear la categoria en el repositorio
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Error al crear la categoria"); //Error al crear la categoria
            }

            //Mapear la entidad creada a Dto
            return _mapper.Map<CategoryDto>(category);


        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            //Verificar si la categoria existe
            var categoryExist = await _categoryRepository.GetCategoryAsync(id);
            if (categoryExist == null)
            {
                throw new InvalidOperationException($"No se encontro la categoria con ID'{id}' "); //La categoria ya existe
            }
            //Eliminar la categoria
            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(id);

            if (!categoryDeleted)
            {
                throw new Exception("Error al eliminar la categoria"); //Error al crear la categoria
            }

            return categoryDeleted;
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();//Lamando el metodo desde la capa de repository

            return  _mapper.Map<ICollection<CategoryDto>>(categories);//Mapeando la lista de categorias a una lista de categorias DTO

           
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);//Lamando el metodo desde la capa de repository

            if (category == null)
            {
                throw new InvalidOperationException($"No se encontro la categoria con ID'{id}' "); //La categoria ya existe
            }

            return _mapper.Map<CategoryDto>(category);//Mapeando la lista de categorias a una lista de categorias DTO
        }

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto dto, int id)
        {
            

            //Validar si la categoria ya existe
            var categoryExist = await _categoryRepository.GetCategoryAsync(id);

            if (categoryExist == null)
            {
                throw new InvalidOperationException($"No se encontro la categoria con ID'{id}' "); //La categoria ya existe
            }

            var nameExist = await _categoryRepository.CategoryExistsByNameAsync(dto.Name);

            if (nameExist)            
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{dto.Name}' "); //La categoria ya existe
            }


            //Mapear el DTO a la entidad Category
            _mapper.Map(dto, categoryExist);    

          //Actualizamos la categoria
          var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(categoryExist);
            if (!categoryUpdated)
            {
                throw new Exception("Error al actualizar la categoria"); //Error al crear la categoria
            }
            //Retornar el Dto Actualizado
            return _mapper.Map<CategoryDto>(categoryExist);
        }

       
    }
}
