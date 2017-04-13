namespace Eventis.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System;
    using Models.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Eventis.Models.IdentityConfig+ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                CreateUser(context, "Admin@gmail.com", "Admin@gmail.com");
                CreateUser(context, "gosho@gmail.com", "123");
                CreateUser(context, "pesho@gmail.com", "123");
                CreateUser(context, "merry@gmail.com", "123");

                CreateRole(context, "Administrators");
                AddUserToRole(context, "Admin@gmail.com", "Administrators");
            }
            context.SaveChanges();
        }

        private void CreateUser(ApplicationDbContext context, 
            string email,
            string password
            )
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context))
            {
                PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 1,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                }
            };
            var user = new ApplicationUser {
                UserName = email,
                Email = email,
            };
            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }
        private void CreateRole(ApplicationDbContext db, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(db));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private static void AddUserToRole(ApplicationDbContext db, string userName, string roleName)
        {
            var user = db.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(db));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }
    }
}
