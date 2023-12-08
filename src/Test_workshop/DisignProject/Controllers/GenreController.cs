using DisignProject.Interfaces;
using DisignProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DisignProject.Controllers
{
    public class GenreController : Controller
    {

        private readonly IGenre _genreRepository;
        private readonly IMovie _movieRepository;

        public GenreController(IGenre genreRepository, IMovie movieRepository)
        {
            _genreRepository = genreRepository;
            _movieRepository = movieRepository;
        }
        public async Task<IActionResult> Index()
        {
            var generes = await _genreRepository.GetItemsAsync();
            return View(generes);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var genre = new Genre();
            PopulateViewBagsAsync().GetAwaiter().GetResult();
            return View(genre);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            var bolret = false;
            string errMessage = "";

            try
            {
                if (_genreRepository.IsItemNameExists(genre.Name) == true)
                    errMessage = errMessage + " " + " Genre Name " + genre.Name + " Exists Already";

                if (errMessage == "")
                {
                    genre = await _genreRepository.GreateAsync(genre);
                    bolret = true;
                }

            }
            catch (Exception ex) { errMessage = errMessage + " " + ex.Message; }

            if (bolret == false)
            {
                await PopulateViewBagsAsync();
                return View(genre);
            }
            else { return RedirectToAction(nameof(Index)); }

        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var genre = await _genreRepository.GetItemAsync(id);

            if (genre != null)
            {
                return View(genre);
            }

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var genre = await _genreRepository.GetItemAsync(id);

            await PopulateViewBagsAsync();

            if (genre != null)
            {
                return View(genre);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Genre genre)
        {
            var bolret = false;
            string errMessage = "";

            try
            {
                if (_genreRepository.IsItemNameExists(genre.Name, genre.Id) == true)
                    errMessage = errMessage + " " + " Genre Name " + genre.Name + " Exists Already";

                if (errMessage == "")
                {
                    genre = await _genreRepository.EditAsync(genre);
                    bolret = true;
                }

            }
            catch (Exception ex) { errMessage = errMessage + " " + ex.Message; }

            if (bolret == false)
            {
                ModelState.AddModelError("", errMessage);
                await PopulateViewBagsAsync();
                return View(genre);
            }
            else { return RedirectToAction(nameof(Index)); }
        }



        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var genre = await _genreRepository.GetItemAsync(id);

            if (genre != null)
            {
                return View(genre);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Genre genre)
        {
            try
            {
                genre = await _genreRepository.DeleteAsync(genre);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                ModelState.AddModelError("", errMessage);
                return View(genre);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateViewBagsAsync()
        {
            ViewBag.Movies = await GetMoviesAsync();
        }

        private async Task<List<SelectListItem>> GetMoviesAsync()
        {
            List<SelectListItem> listIItems = new List<SelectListItem>();

            var items = await _movieRepository.GetItemsAsync();

            listIItems = items.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            SelectListItem defItem = new SelectListItem()
            {
                Text = "---Select Movie---",
                Value = ""
            };

            listIItems.Insert(0, defItem);
            return listIItems;
        }

    }
}
