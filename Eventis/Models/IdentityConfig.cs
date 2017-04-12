using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eventis.Models
{
    public class IdentityConfig
    {
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public virtual DbSet<Event> Events { get; set; }

            public virtual DbSet<Contact> Contacts { get; set; }

            public virtual DbSet<Comment> Comments { get; set; }

            public virtual DbSet<Category> Categories { get; set; }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
    }
}