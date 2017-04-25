using Eventis.Models.Eventis;
using Eventis.Models.Identity;
using System.Web.Mvc;
using System.Net;
using System.Linq;
using Microsoft.AspNet.Identity;
using Eventis.Models.Eventis.ViewModels;

namespace Eventis.Controllers
{
    public class CommentController : Controller
    {
        [Authorize]
        [HttpPost]
        public ActionResult Create(CommentViewModel model)
        {
            var loggedInUserId = this.User.Identity.GetUserId();

            var comment = new Comment()
            {
                Content = model.Content,
                AuthorId = loggedInUserId,
                EventId = model.EventId
            };

            if (model.Content == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You must enter some content.");
            }

            var db = new ApplicationDbContext();

            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Details", "Events", new { Id = model.EventId });
        }
    }
}