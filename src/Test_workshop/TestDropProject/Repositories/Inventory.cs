using TestDropProject.Interfaces;
using TestDropProject.Models;
using TestDropProject.Data;
using Microsoft.EntityFrameworkCore;

namespace TestDropProject.Repositories
{
    public class Inventory : IInventory
    {
        private readonly ApplicationContext _IvenContext;

        public Inventory(ApplicationContext custDbcontext)
        {
            _IvenContext = custDbcontext;
        }
        public async Task<IEnumerable<Country>> Getcountries()
        {
            return await _IvenContext.Countries.ToListAsync();
        }
    }
}
