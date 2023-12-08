using TestDropProject.Models;

namespace TestDropProject.Interfaces
{
    public interface IInventory
    {
        Task<IEnumerable<Country>> Getcountries();
    }
}
