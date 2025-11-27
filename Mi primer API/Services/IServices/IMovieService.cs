using Mi_primer_API.DAL.Models;
using Mi_primer_API.DAL.Models.Dto;

namespace Mi_primer_API.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync(); //Me retorna una lista de peliculas

        Task<MovieDto> GetMovieAsync(int id); //Me retorna una pelicula por id

        Task<bool> MovieExistsByIdAsync(int id); //Me retorna true o false si existe la pelicula por id

        Task<bool> MovieExistsByNameAsync(string name); //Me retorna true o false si existe la pelicula por nombre

        Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieDto); //Me crea una pelicula

        Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id); //Me actualiza una pelicula

        Task<bool> DeleteMovieAsync(int id); //Me elimina una pelicula
    }
}
