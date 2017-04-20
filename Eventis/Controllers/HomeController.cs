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
                .Include(x=>x.Contact)
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
    }
}