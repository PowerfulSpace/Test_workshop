using DisignProject.Interfaces.Base;
using DisignProject.Models;

namespace DisignProject.Interfaces
{
    public interface IGenre : IBaseRepository<Genre>
    {
        public bool IsItemNameExists(string name);
        public bool IsItemNameExists(string name, Guid id);
    }
}
