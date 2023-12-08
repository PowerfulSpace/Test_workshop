using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestDropProject.Models
{
    public class countryModel
    {

        public int countryId { get; set; }
        public string countryName { get; set; }
        public List<SelectListItem> Countrys { get; set; }
        public int[] CountryIds { get; set; }


    }
}
