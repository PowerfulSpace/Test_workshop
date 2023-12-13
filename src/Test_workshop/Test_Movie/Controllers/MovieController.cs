using Test_Movie.Interfaces;
using Test_Movie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Humanizer;

namespace Test_Movie.Controllers
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
        public async Task<IActionResult> Create(Movie movie, List<Guid> genres)
        {
            var bolret = false;
            string errMessage = "";

            try
            {
                if (_movieRepository.IsItemNameExists(movie.Name) == true)
                    errMessage = errMessage + " " + " Movie Name " + movie.Name + " Exists Already";

                if (errMessage == "")
                {

                    if (genres != null)
                    {
                        movie = await AddGeneresAsync(movie, genres);
                    }

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

            TempData["Movie"] = movie;
            TempData.Keep("Movie");

            await PopulateViewBagsAsync(movie.Genres.Select(x => x.Id).ToList());

            if (movie != null)
            {
                return View(movie);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie, List<Guid> genres)
        {
            var a = TempData["Movie"];

            var bolret = false;
            string errMessage = "";

            try
            {
                if (_movieRepository.IsItemNameExists(movie.Name, movie.Id) == true)
                    errMessage = errMessage + " " + " Movie Name " + movie.Name + " Exists Already";

                if (errMessage == "")
                {

                    //if (genres != null)
                    //{
                    //    movie = await EditGeneresAsync(movie, genres);
                    //}

                    //movie = await _movieRepository.EditAsync(movie);

                    movie = await _movieRepository.EditGenresAsync(movie, genres);
                    bolret = true;
                }

            }
            catch (Exception ex) { errMessage = errMessage + " " + ex.Message; }

            if (bolret == false)
            {
                ModelState.AddModelError("", errMessage);
                await PopulateViewBagsAsync(genres);
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

        private async Task PopulateViewBagsAsync(List<Guid> genersId = null!)
        {
            if (genersId == null)
            {
                ViewBag.Genres = await GetGenresAsync();
            }
            else
            {
                ViewBag.Genres = await GetGenresAsync(genersId);
            }
           
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

        private async Task<List<SelectListItem>> GetGenresAsync(List<Guid> genersId)
        {
            List<SelectListItem> listIItems = new List<SelectListItem>();

            var items = await _genreRepository.GetItemsAsync();

            listIItems = items.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = genersId.Contains(x.Id)
            }).ToList();


            return listIItems;
        }


        private async Task<Movie> AddGeneresAsync(Movie movie, List<Guid> genres)
        {
            List<Genre> allGenres = await _genreRepository.GetItemsAsync();
            List<Genre> genresList = new List<Genre>();


            foreach (var genre in genres)
            {
                genresList.AddRange(allGenres.Where(x => x.Id == genre).ToList());
            }
            movie.Genres.AddRange(genresList);

            return movie;
        }

        private async Task<Movie> EditGeneresAsync(Movie movie, List<Guid> genres)
        {
            //Выбираем фильм до изменения, вытакскиваем все жанры которые были изначально
            Movie movieBeforeChange = await _movieRepository.GetItemAsync(movie.Id);
            List<Genre> genreBeforeChange = movieBeforeChange.Genres;

            //Выбираем сначала все жанры, что бы выбрать по пришедшим id жанры которые выбранны сейчас
            List<Genre> allGenres = await _genreRepository.GetItemsAsync();
            List<Genre> genreAfterChange = new List<Genre>();
            foreach (var genre in genres)
            {
                genreAfterChange.AddRange(allGenres.Where(x => x.Id == genre).ToList());
            }

            //Выбираю те жанры которые были до изменения, и их не стало после изменения, что бы
            //Удалить их из таблицы на для коллекции фильмов
            List<Genre> genresToDelete = genreBeforeChange.Except(genreAfterChange).ToList();

            //Выбираю жанры которые были до измения, и которые остались после, что бы ни какие
            //действия с ними не делать
            List<Genre> genresUnchanged = genreBeforeChange.Intersect(genreAfterChange).ToList();

            //Выбираю жанры которые нужно будет добавить в коллекию к фильму
            List<Genre> genresToAdd = genreAfterChange.Except(genresUnchanged).ToList();

            foreach (var item in genresToDelete)
            {
                movie.Genres.Remove(item);
            }
            
            movie.Genres.AddRange(genresToAdd);

            return movie;
        }

    }
}
