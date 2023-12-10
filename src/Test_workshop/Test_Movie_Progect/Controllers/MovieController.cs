using Test_Movie_Progect.Interfaces;
using Test_Movie_Progect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DisignProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovie _movieRepository;
        private readonly IGenre _genreRepository;

        public MovieController(IMovie movieRepository, IGenre genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepository.GetItemsAsync();
            return View(movies);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var movie = new Movie();
            PopulateViewBagsAsync().GetAwaiter().GetResult();
            return View(movie);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            var bolret = false;
            string errMessage = "";

            try
            {
                if (_movieRepository.IsItemNameExists(movie.Name) == true)
                    errMessage = errMessage + " " + " Movie Name " + movie.Name + " Exists Already";

                if (errMessage == "")
                {
                    movie = await _movieRepository.GreateAsync(movie);
                    bolret = true;
                }

            }
            catch (Exception ex) { errMessage = errMessage + " " + ex.Message; }

            if (bolret == false)
            {
                await PopulateViewBagsAsync();
                return View(movie);
            }
            else { return RedirectToAction(nameof(Index)); }

        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieRepository.GetItemAsync(id);

            if (movie != null)
            {
                return View(movie);
            }

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var movie = await _movieRepository.GetItemAsync(id);

            await PopulateViewBagsAsync();

            if (movie != null)
            {
                return View(movie);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie)
        {
            var bolret = false;
            string errMessage = "";

            try
            {
                if (_movieRepository.IsItemNameExists(movie.Name, movie.Id) == true)
                    errMessage = errMessage + " " + " Movie Name " + movie.Name + " Exists Already";

                if (errMessage == "")
                {
                    movie = await _movieRepository.EditAsync(movie);
                    bolret = true;
                }

            }
            catch (Exception ex) { errMessage = errMessage + " " + ex.Message; }

            if (bolret == false)
            {
                ModelState.AddModelError("", errMessage);
                await PopulateViewBagsAsync();
                return View(movie);
            }
            else { return RedirectToAction(nameof(Index)); }
        }



        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = await _movieRepository.GetItemAsync(id);

            if (movie != null)
            {
                return View(movie);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Movie movie)
        {
            try
            {
                movie = await _movieRepository.DeleteAsync(movie);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                ModelState.AddModelError("", errMessage);
                return View(movie);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateViewBagsAsync()
        {
            ViewBag.Genres = await GetGenresAsync();
        }

        private async Task<List<SelectListItem>> GetGenresAsync()
        {
            List<SelectListItem> listIItems = new List<SelectListItem>();

            var items = await _genreRepository.GetItemsAsync();

            listIItems = items.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            SelectListItem defItem = new SelectListItem()
            {
                Text = "---Select Genre---",
                Value = ""
            };

            listIItems.Insert(0, defItem);
            return listIItems;
        }


    }
}
