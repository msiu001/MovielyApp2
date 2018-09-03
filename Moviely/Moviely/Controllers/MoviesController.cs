using Moviely.Models;
using System.Data.Entity; //to use this line: var movies = _context.Movies.Include(m => m.Genre).ToList();
using Moviely.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace Moviely.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            try
            {
                if (movie.Id == 0)
                {
                    _context.Movies.Add(movie);
                }   
           
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            return RedirectToAction("Index", "Movies");

        }



        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            else
                return View(movie);
        }

        //// GET: Movies
        //public ActionResult Random()
        //{
        //    var movie = new Movie()
        //    {
        //        Name = "Interestelar"
        //    };

        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1"},
        //        new Customer { Name = "Customer 2"}
        //    };


        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }


        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie { Id = 1, Name = "Interestellar" },
        //        new Movie { Id = 2, Name = "Jurassic Park" },
        //        new Movie { Id = 3, Name = "Avatar" },
        //        new Movie { Id = 4, Name = "Back to the Future" }
        //    };
        //}

        //public ActionResult Edit (int id)
        //{
        //    return Content("id=" + id);
        //}

        //public ActionResult Index(int pageIndex, string sortBy)
        //{
        //    if (!pageIndex.hasValue) { }
        //}
    }
}