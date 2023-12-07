using DisignProject.Interfaces;
using DisignProject.Models;

namespace DisignProject.Repositories
{
    public class GenreRepository : IGenre
    {
        public Task<Genre> DeleteAsync(Genre item)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> EditAsync(Genre item)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Genre>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GreateAsync(Genre item)
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
