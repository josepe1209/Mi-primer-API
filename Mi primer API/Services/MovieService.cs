using AutoMapper;
using Mi_primer_API.DAL.Models;
using Mi_primer_API.DAL.Models.Dto;
using Mi_primer_API.Repository;
using Mi_primer_API.Repository.IRepository;
using Mi_primer_API.Services.IServices;

namespace Mi_primer_API.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper) 
        {
            _movieRepository = movieRepository;
            _mapper = mapper;

        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            //validar si la pelicula ya existe
            var movieExist = await _movieRepository.MovieExistsByNameAsync(movieCreateDto.Name);

            if (movieExist)
            {
                throw new InvalidOperationException($"Ya esxite una pelicula con el nombre de {movieCreateDto.Name}");
            }

            //Mapear el DTO a la entidad Movie
            var movie = _mapper.Map<Movie>(movieCreateDto);

            //Crear la pelicula en el repositorio
            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("Ocurrio un error al crear la pelicula");
            }
            //Mapear la entidad creada a Dto
            return _mapper.Map<MovieDto>(movie);


        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            //Verificar si la categoria existe
            var movieExist = await _movieRepository.GetMovieAsync(id);

            if (movieExist == null)
            {
                throw new InvalidOperationException($"No se encontro la pelicula con ID: {id}"); //La pelicula no existe
            }
            //Eliminar la pelicula
            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);
            if (!movieDeleted)
            {
                throw new Exception("Ocurrio un error al eliminar la pelicula"); //Error al eliminar la pelicula
            }
            return movieDeleted;
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontro la pelicula con ID: {id}"); //La pelicula no existe
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();

            return _mapper.Map<ICollection<MovieDto>>(movies);
       
        }

        public Task<bool> MovieExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

      

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
           

            //validar si la pelicula ya existe
            var movieExist = await _movieRepository.GetMovieAsync(id);

            if (movieExist == null)
            {
                throw new InvalidOperationException($"No se encontro una pelicula con el id:{id}");
            }

            var nameExist = await _movieRepository.MovieExistsByNameAsync(dto.Name);

            if (nameExist)
            {
                throw new InvalidOperationException($"Ya esxite una pelicula con el nombre de {dto.Name}");
            }


            //Mapear el DTO a la entidad Movie
             _mapper.Map(dto, movieExist);

            //Actualizar la pelicula 
            var movieUpdated = await _movieRepository.UpdateMovieAsync(movieExist);

            if (!movieUpdated)
            {
                throw new Exception("Ocurrio un error al actualizar la pelicula");
            }

            //retornar el dto
            return _mapper.Map<MovieDto>(movieExist);

        }
    }
}
