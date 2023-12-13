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


        //Найти все жанры которые удулил
        //Найти все жанры которые добивил
        //И по коллекции сначала удалить а потом добавить

        public async Task<Movie> EditAsync(Movie item)
        {
            var count = _context.ChangeTracker.Entries();

            _context.Movies.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }

        //Ошибка в Movie movieBeforeChange = await GetItemAsync(movie.Id); . Т.к id используется повторно
        //Думаю как обойти
        public async Task<Movie> EditGenresAsync(Movie movie, List<Guid> genres)
        {
            //Выбираем фильм до изменения, вытакскиваем все жанры которые были изначально
            Movie movieBeforeChange = await GetItemAsync(movie.Id);
            List<Genre> genreBeforeChange = movieBeforeChange.Genres;

            //Выбираем сначала все жанры, что бы выбрать по пришедшим id жанры которые выбранны сейчас
            List<Genre> allGenres = await _context.Genres.ToListAsync();
            List<Genre> genreAfterChange = new List<Genre>();
            foreach (var genre in genres)
            {
                genreAfterChange.AddRange(allGenres.Where(x => x.Id == genre).ToList());
            }

            //Выбираю те жанры которые были до изменения, и их не стало после изменения, что бы
            //Удалить их из таблицы на для коллекции фильмов
            List<Genre> genresToDelete = genreBeforeChange.Except(genreAfterChange).ToList();

            //Выбираю жанры которые были до измения, и которые остались после, что бы ни какие
            //действия с ними не делать
            List<Genre> genresUnchanged = genreBeforeChange.Intersect(genreAfterChange).ToList();

            //Выбираю жанры которые нужно будет добавить в коллекию к фильму
            List<Genre> genresToAdd = genreAfterChange.Except(genresUnchanged).ToList();

            

            if(genresToDelete != null)
            {
                foreach (var item in genresToDelete)
                {
                    movie.Genres.Remove(item);
                }
            }

            if(genresToAdd != null)
            {
                movie.Genres.AddRange(genresToAdd);
            }

            _context.Movies.Attach(movie);
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return movie;
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
