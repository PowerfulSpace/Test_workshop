using DisignProject.Interfaces;
using DisignProject.Models;

namespace DisignProject.Repositories
{
    public class MovieRepository : IMovie
    {
        public Task<Movie> DeleteAsync(Movie item)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> EditAsync(Movie item)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GreateAsync(Movie item)
        {
            throw new NotImplementedException();
        }

        public bool IsItemNameExists(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsItemNameExists(string name, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
