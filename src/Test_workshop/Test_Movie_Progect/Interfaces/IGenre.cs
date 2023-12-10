using Test_Movie_Progect.Interfaces.Base;
using Test_Movie_Progect.Models;

namespace Test_Movie_Progect.Interfaces
{
    public interface IGenre : IBaseRepository<Genre>
    {
        public bool IsItemNameExists(string name);
        public bool IsItemNameExists(string name, Guid id);
    }
}
