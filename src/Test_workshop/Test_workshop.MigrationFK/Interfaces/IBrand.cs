using Microsoft.Data.SqlClient;
using Test_workshop.MigrationFK.Models;

namespace Test_workshop.MigrationFK.Interfaces
{
    public interface IBrand
    {
        PaginatedList<Brand> GetItems(string sortProperty, SortOrder order, string searchText, int pageIndex, int pageSize);
        Brand GetItem(Guid id);
        Brand Greate(Brand item);
        Brand Edit(Brand item);
        Brand Delete(Brand item);

        public bool IsItemNameExists(string name);
        public bool IsItemNameExists(string name, Guid id);
    }
}
