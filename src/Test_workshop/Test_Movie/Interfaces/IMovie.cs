using Test_Movie.Interfaces.Base;
using Test_Movie.Models;

namespace Test_Movie.Interfaces
{
    public interface IMovie : IBaseRepository<Movie>
    {
        public bool IsItemNameExists(string name);
        public bool IsItemNameExists(string name, Guid id);


        public Task<Movie> EditGenresAsync(Movie movie, List<Guid> genres);
    }
}
