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
            return View(hall);
        }
        public ActionResult Genres(int id)
        {
            var db = new ApplicationDbContext();

           var genre = db.Events
                .Where(g => g.Genre.Id == id)
                .Include(c => c.Category)
                .Include(g => g.Genre)
                .Include(g => g.Hall)
                .ToList();

            return View(genre);
        }

    }
}