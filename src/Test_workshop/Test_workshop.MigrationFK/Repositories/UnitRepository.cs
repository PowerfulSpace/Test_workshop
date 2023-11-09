using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Test_workshop.MigrationFK.Data;
using Test_workshop.MigrationFK.Interfaces;
using Test_workshop.MigrationFK.Models;

namespace Test_workshop.MigrationFK.Repositories
{
    public class UnitRepository : IUnit
    {
        private readonly InventoryContext _context;

        public UnitRepository(InventoryContext context)
        {
            _context = context;
        }
        public PaginatedList<Unit> GetItems(string sortProperty, SortOrder order, string searchText, int pageIndex, int pageSize)
        {
            List<Unit> items;

            if (searchText != "" && searchText != null)
            {
                items = _context.Units
                    .Where(x => x.Name.Contains(searchText) || x.Description.Contains(searchText))
                    .ToList();
            }
            else
            {
                items = _context.Units.ToList();
            }

            items = DoSort(items, sortProperty, order);

            PaginatedList<Unit> retUnits = new PaginatedList<Unit>(items, pageIndex, pageSize);

            return retUnits;
        }

        public Unit GetItem(Guid id) => _context.Units.FirstOrDefault(x => x.Id == id);


        public Unit Greate(Unit item)
        {
            _context.Units.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Unit Edit(Unit item)
        {
            _context.Units.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        public Unit Delete(Unit item)
        {
            _context.Units.Attach(item);
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
            return item;
        }

        public bool IsItemNameExists(string name)
        {
            int ct = _context.Units.Where(x => x.Name.ToLower() == name.ToLower()).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }
        public bool IsItemNameExists(string name, Guid id)
        {
            int ct = _context.Units.Where(x => x.Name.ToLower() == name.ToLower() && x.Id != id).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }


        private List<Unit> DoSort(List<Unit> items, string sortProperty, SortOrder order)
        {
            if (sortProperty.ToLower() == "name")
            {
                if (order == SortOrder.Ascending)
                    items = items.OrderBy(x => x.Name).ToList();
                else
                    items = items.OrderByDescending(x => x.Name).ToList();
            }
            else if (sortProperty.ToLower() == "description")
            {
                if (order == SortOrder.Ascending)
                    items = items.OrderBy(x => x.Description).ToList();
                else
                    items = items.OrderByDescending(x => x.Description).ToList();
            }

            return items;
        }


    }
}
