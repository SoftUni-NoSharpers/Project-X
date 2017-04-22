using Eventis.Models.Identity;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace Eventis.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();

            var events = db.Events
                .OrderByDescending(c => c.Id)
                .Take(6)
                .Include(x => x.Contact)
                .Include(x => x.Author)
                .Include(x => x.Category)
                .ToList();

            return View(events);
        }

        public ActionResult ListAll(int page = 1)
        {
            var db = new ApplicationDbContext();

            var pageSize = 6;

            var events = db.Events
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Contact)
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Genre)
                .ToList();

            ViewBag.CurrentPage = page;

            return View(events);
        }

        public ActionResult Cities()
        {
            var db = new ApplicationDbContext();

            var city = db
                .Cities
                .Include(h => h.Halls).
                ToList();

            return View(city);
        }

        public ActionResult Categories()
        {
            var db = new ApplicationDbContext();

            var categories = db.Categories.Include(g => g.Genres).ToList();

            return View(categories);
        }
        public ActionResult Halls(int id)
        {
            
            var db = new ApplicationDbContext();
           
            var hall = db.Events
                .Where(e => e.HallId == id)
                .Include(c => c.Category)
                .Include(g => g.Genre)
                .Include(g => g.Hall)
                .ToList();
            var hallname = db.Halls.Where(g => g.Id == id);
            ViewBag.Title = hallname.First().Name;
            return View(hall);
        }
        public ActionResult Genres(int id)
        {
            
            var db = new ApplicationDbContext();
            var events = db.Events
                .Where(g => g.Genre.Id == id)
                .Include(c => c.Category)
                .Include(g => g.Genre)
                .Include(g => g.Hall)
                .ToList();

            var genre = db.Genres.Where(g => g.Id == id);
            ViewBag.Title = genre.First().Name;
            return View(events);
        }

    }
}