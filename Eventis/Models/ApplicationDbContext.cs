using Eventis.Models.Eventis;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Eventis.Models.Identity
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Hall> Halls { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}