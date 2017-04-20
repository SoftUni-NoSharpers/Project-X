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

            var city = db.Cities.ToList();

            return View(city);
        }
    }
}