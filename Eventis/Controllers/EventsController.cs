using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Eventis.Models.Identity;
using Eventis.Models.Eventis;
using Microsoft.AspNet.Identity;
using Eventis.Models.CRUD;
using System;
using System.Globalization;

namespace Eventis.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            var db = new ApplicationDbContext();

            var events = db.Events
                .Where(c => c.Id == id)
                .Include(x => x.Contact)
                .Include(x => x.Author)
                .Include(x => x.Genre.Category)
                .Include(x => x.Genre)
                .FirstOrDefault();

            if (events == null)
            {
                return HttpNotFound();
            }

            events.ViewCount++;
            db.Entry(events).State = EntityState.Modified;
           
            db.SaveChanges();
            var viewBagName = db.Events.Where(i => i.Id == id);
            ViewBag.Title = viewBagName.First().Title;
            return View(events);
        }

        // GET: Events/Create
        [Authorize]
        public ActionResult CreateEvent()
        {
            var db = new ApplicationDbContext();
            var categories = db.Categories.ToList();
            var genres = db.Genres.ToList();
            var cities = db.Cities.ToList();
            var halls = db.Halls.ToList();
            
            ViewBag.Categories = categories;
            ViewBag.Genres = genres;
            ViewBag.Cities = cities;
            ViewBag.Halls = halls;

            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(CreateEvent model)
        {
            if (ModelState.IsValid)
            {
                var db = new ApplicationDbContext();

                var authorId = this.User.Identity.GetUserId();
                //var catecory = string.Format("{0}", Request.Form["mycat"]);
                //var catId = db.Categories.Where(e => e.Name == catecory).FirstOrDefault().Id;
                var gener = string.Format("{0}", Request.Form["mygen"]);
                var generId = db.Genres.Where(g => g.Name == gener).FirstOrDefault().Id;
                var city = string.Format("{0}", Request.Form["mycity"]);
                var cityId = db.Cities.Where(c => c.Name == city).FirstOrDefault().Id;
                var hall = string.Format("{0}", Request.Form["myhall"]);
                var hallId = db.Halls.Where(h => h.Name == hall).FirstOrDefault().Id;
                var stringDate = string.Format("{0}", Request.Form["mydate"]);
                var date = DateTime.ParseExact(stringDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                
                var ev = new Event
                {
                    Title = model.Title,
                    Content = model.Content,
                    //CategoryId = catId,
                    GenreId = generId,
                    ImagePath = model.ImagePath,
                    Status = model.Status,
                    StartDate = date,
                    AuthorId = authorId,
                    HallId = hallId
                };
                
                var contInfo = new Contact
                {
                    Name = authorId,
                    EmailAddress = this.User.Identity.Name
                };


                db.Events.Add(ev);
                db.SaveChanges();
                db.Contacts.Add(contInfo);
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }
            return View(model);
        }

        // GET: Events/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }

            CreateEvent ev = new CreateEvent();

            var city = string.Format("{0}", Request.Form["mycity"]);
            var gener = string.Format("{0}", Request.Form["mygen"]);
            var hall = string.Format("{0}", Request.Form["myhall"]);

            ev.CategoryName = events.Genre.Category.Name;
            ev.CityName = db.Cities.Where(c => c.Id == events.Hall.CityId).FirstOrDefault().Name;
            ev.Content = events.Content;
            ev.GenreName = db.Genres.Where(g => g.Name == events.Genre.Name).FirstOrDefault().Name;
            ev.HallName = db.Halls.Where(h => h.Name == events.Hall.Name).FirstOrDefault().Name; ;
            ev.ImagePath = events.ImagePath;
            ev.StartDate = events.StartDate;
            ev.Status = events.Status;
            ev.Title = events.Title;
            
            var categories = db.Categories.ToList();
            var genres = db.Genres.ToList();
            var cities = db.Cities.ToList();
            var halls = db.Halls.ToList();

            ViewBag.Categories = categories;
            ViewBag.Genres = genres;
            ViewBag.Cities = cities;
            ViewBag.Halls = halls;

            return View(ev);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event events)
        {
            var cat = string.Format("{0}",Request.Form["mycat"]);
            var city = string.Format("{0}", Request.Form["mycity"]);
            var gener = string.Format("{0}", Request.Form["mygen"]);
            var hall = string.Format("{0}", Request.Form["myhall"]);

            events.AuthorId = db.Events.Select(i => i.AuthorId).First();
            //events.CategoryId = db.Categories.Where(c => c.Name == cat).First().Id;
            events.HallId = db.Halls.Where(h => h.Name == hall).First().Id;
            events.GenreId = db.Genres.Where(g => g.Name == gener).First().Id;
            //events.Hall.CityId = db.Cities.Where(c => c.Name == city).First().Id;
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Events", new { Id = events.Id });
            }
            return View(events);
        }

        // GET: Events/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event events = db.Events
                .Where(e => e.Id == id)
                .Include(e => e.Author)
                .Include(e => e.Comments)
                .First();

            if (events == null)
            {
                return HttpNotFound();
            }

            DeleteEvent ev = new DeleteEvent();

            var city = string.Format("{0}", Request.Form["mycity"]);
            var gener = string.Format("{0}", Request.Form["mygen"]);
            var hall = string.Format("{0}", Request.Form["myhall"]);

            ev.Category = events.Genre.Category.Name;
            ev.City = db.Cities.Where(c => c.Id == events.Hall.CityId).FirstOrDefault().Name;
            ev.Content = events.Content;
            ev.Genre = db.Genres.Where(g => g.Name == events.Genre.Name).FirstOrDefault().Name;
            ev.Hall = db.Halls.Where(h => h.Name == events.Hall.Name).FirstOrDefault().Name; ;
            ev.ImagePath = events.ImagePath;
            ev.StartDate = events.StartDate;
            ev.Status = events.Status;
            ev.Title = events.Title;
            ev.Comments = events.Comments;

            return View(ev);
        }

        // POST: Events/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event events = db.Events.Find(id);
            db.Events.Remove(events);
            db.SaveChanges();
            return RedirectToAction("/../Home/ListAll");
        }

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
