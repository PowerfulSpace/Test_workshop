using Test_Movie.Interfaces.Base;
using Test_Movie.Models;

namespace Test_Movie.Interfaces
{
    public interface IGenre : IBaseRepository<Genre>
    {
        public bool IsItemNameExists(string name);
        public bool IsItemNameExists(string name, Guid id);
    }
}
