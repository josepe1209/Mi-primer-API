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

        public Task<bool> CreateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDto> GetMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();

            return _mapper.Map<ICollection<MovieDto>>(movies);
       
        }

        public Task<bool> UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
