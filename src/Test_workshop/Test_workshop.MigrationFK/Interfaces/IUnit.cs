using Microsoft.Data.SqlClient;
using Test_workshop.MigrationFK.Models;

namespace Test_workshop.MigrationFK.Interfaces
{
    public interface IUnit
    {
        PaginatedList<Unit> GetItems(string sortProperty, SortOrder order, string searchText, int pageIndex, int pageSize);
        Unit GetItem(Guid id);
        Unit Greate(Unit item);
        Unit Edit(Unit item);
        Unit Delete(Unit item);

        public bool IsItemNameExists(string name);
        public bool IsItemNameExists(string name, Guid id);
    }
}
