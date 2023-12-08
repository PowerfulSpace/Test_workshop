using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestDropProject.Interfaces;
using TestDropProject.Models;

namespace TestDropProject.Controllers
{
    public class InventoryController : Controller
    {
        // GET: InventoryController
        private readonly IInventory _Ivencontext;

        public InventoryController(IInventory ivencontext)
        {
            _Ivencontext = ivencontext;
        }
        public ActionResult Index()
        {
            countryModel country = new countryModel();
            country.Countrys = _Ivencontext.Getcountries().Result.Select(k => new SelectListItem
            {
                Text = k.countryName,
                Value = Convert.ToString(k.countryId)
            }).ToList();
            return View(country);
        }
        [HttpPost]
        public IActionResult Multiselect(countryModel country)
        {
            var countriesid = country.CountryIds;
            var model = _Ivencontext.Getcountries().Result.Where(p => countriesid.Contains(p.countryId));
            return Ok();
        }
    }
}
