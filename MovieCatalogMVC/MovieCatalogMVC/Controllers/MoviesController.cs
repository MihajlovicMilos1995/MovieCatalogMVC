using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MovieCatalogMVC.Models;
using System;

namespace MovieCatalogMVC.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Movies
        //public ActionResult Index()
        //{
        //    return View(db.Movies.ToList());
        //}

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Genre,Director,ReleaseDate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Genre,Director,ReleaseDate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //search #1

        public ActionResult Index(string searchString, string sortOrder)
        {
            //var movies = from m in db.Movies
            //             select m;

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    movies = movies.Where(s => s.Name.Contains(searchString));
            //}

            //sort

            var movies = from m in db.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Name.Contains(searchString));
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_MovieSearchResults", movies);
            }


        ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.GenreSortParm = sortOrder == "Genre" ? "GenreDesc" : "Genre";
            ViewBag.DirectorSortParm = sortOrder == "Director" ? "DirectorDesc" : "Director";


            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    movies = movies.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "Genre":
                    movies = movies.OrderBy(s => s.Genre);
                    break;
                case "GenreDesc":
                    movies = movies.OrderByDescending(s => s.Genre);
                    break;
                case "Director":
                    movies = movies.OrderBy(s => s.Director);
                    break;
                case "DirectorDesc":
                    movies = movies.OrderByDescending(s => s.Director);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Name);
                    break;
            }

            return View(movies);
        }

        //search #2

        //public ActionResult Search(string searchString)
        //{
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
