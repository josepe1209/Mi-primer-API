using Mi_primer_API.DAL;
using Mi_primer_API.DAL.Models;
using Mi_primer_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Mi_primer_API.Repository
{
    public class MovieRepository: IMovieRepository
    {

        private readonly ApplicationDBContext _context;
        public MovieRepository(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;

            await _context.Movies.AddAsync(movie);

            return await SaveAsync();

        }
        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await GetMovieAsync(id);
            if (movie == null)
            {
                return false;// la pelicula no existe
            }

            _context.Movies.Remove(movie);
            return await SaveAsync();
        }
        public async Task<Movie> GetMovieAsync(int id)
        {

            return await _context.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

        }
        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.AsNoTracking().OrderBy(m => m.Name).ToListAsync();
        }
        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.ModifiedDate = DateTime.UtcNow;

            _context.Movies.Update(movie);

            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

    }
}
