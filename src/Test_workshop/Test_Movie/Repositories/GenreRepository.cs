using Test_Movie.Interfaces;
using Test_Movie.Models;
using Test_Movie.Data;
using Microsoft.EntityFrameworkCore;

namespace Test_Movie.Repositories
{
    public class GenreRepository : IGenre
    {

        private readonly ApplicationContext _context;
        public GenreRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetItemsAsync()
        {
            List<Genre> items = await _context.Genres.Include(x => x.Movies).ToListAsync();

            return items;
        }

        public async Task<Genre> GetItemAsync(Guid id)
        {
            var item = await _context.Genres.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id);

            return item!;
        }



        public async Task<Genre> GreateAsync(Genre item)
        {
            await _context.Genres.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<Genre> EditAsync(Genre item)
        {
            _context.Genres.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<Genre> DeleteAsync(Genre item)
        {
            _context.Genres.Attach(item);
            _context.Entry(item).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return item;
        }

        public bool IsItemNameExists(string name)
        {
            int ct = _context.Genres.Where(x => x.Name.ToLower() == name.ToLower()).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }

        public bool IsItemNameExists(string name, Guid id)
        {
            int ct = _context.Genres.Where(x => x.Name.ToLower() == name.ToLower() && x.Id != id).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }
    }
}
