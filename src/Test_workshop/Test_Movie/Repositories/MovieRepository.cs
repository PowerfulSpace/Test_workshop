using Test_Movie.Data;
using Test_Movie.Interfaces;
using Test_Movie.Models;
using Microsoft.EntityFrameworkCore;

namespace Test_Movie.Repositories
{
    public class MovieRepository : IMovie
    {

        private readonly ApplicationContext _context;
        public MovieRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetItemsAsync()
        {
            List<Movie>  items = await _context.Movies.AsNoTracking().Include(x => x.Genres).ToListAsync();

            return items;
        }

        public async Task<Movie> GetItemAsync(Guid id)
        {
            var item = await _context.Movies.Include(x => x.Genres).FirstOrDefaultAsync(x => x.Id == id);

            return item!;
        }



        public async Task<Movie> GreateAsync(Movie item)
        {
            await _context.Movies.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<Movie> EditAsync(Movie item)
        {
            var count = _context.ChangeTracker.Entries();

            _context.Movies.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<Movie> DeleteAsync(Movie item)
        {
            _context.Movies.Attach(item);
            _context.Entry(item).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return item;
        }

        public bool IsItemNameExists(string name)
        {
            int ct = _context.Movies.Where(x => x.Name.ToLower() == name.ToLower()).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }

        public bool IsItemNameExists(string name, Guid id)
        {
            int ct = _context.Movies.Where(x => x.Name.ToLower() == name.ToLower() && x.Id != id).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }
    }
}
