namespace Eventis.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System;
    using Models.Identity;
    using Models.Eventis;

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
            if (!context.Cities.Any())
            {
                CreateCity(context, "SOFIA");
                CreateCity(context, "PLOVDIV");
                CreateCity(context, "VARNA");
                CreateCity(context, "PERNIK");
                CreateCity(context, "STARA ZAGORA");
            }
            if (!context.Categories.Any())
            {
                CreateCategory(context, "Music");
                CreateCategory(context, "Movie");
                CreateCategory(context, "Science");
            }
            if (!context.Genres.Any())
            {
                CreateGenre(context, "Pop Folk", 1);
                CreateGenre(context, "Rock", 1);
                CreateGenre(context, "Techno", 1);
                CreateGenre(context, "Comedy", 2);
                CreateGenre(context, "Horror", 2);
                CreateGenre(context, "Action", 2);
                CreateGenre(context, "Chemistry", 3);
                CreateGenre(context, "Math", 3);
                CreateGenre(context, "Physic", 3);
            }
            if (!context.Halls.Any())
            {
                CreateHall(context, "NDK", "Sofia-Center", 1);
                CreateHall(context, "Universiada", "Sofia-GeoMilev", 1);
                CreateHall(context, "Arena", "Sofia-4km", 1);
                CreateHall(context, "AnticTheathre", "Plovdiv-OldCity", 2);
                CreateHall(context, "City Culture House", "Plovdiv, 15 Gladston Str.", 2);
                CreateHall(context, "Onstage Session", "Plovdiv, 252 6th September Blvd.", 2);
                CreateHall(context, "Varna Live Club", "Varna 22", 3);
                CreateHall(context, "Open Theatre", "Varna 180", 3);
                CreateHall(context, "Rubik Art Center", "бул. „Приморски“ 5 Варна България", 3);
                CreateHall(context, "Bar Epicentar", "Pernik-Center", 4);
                CreateHall(context, "Park bar", "Pernik-Center",4);
                CreateHall(context, "Restorant Romantika", "Pernik-Center", 4);
                CreateHall(context, "Hotel Verea", "STZ-Center", 5);
                CreateHall(context, "Stadion Beroe", "STZ-Aiazmo", 5);
                CreateHall(context, "Restorant Tiffany", "STZ-Center", 5);
            }
            context.SaveChanges();
        }

        private void CreateHall(ApplicationDbContext context, string name, string adress, int id)
        {
            var hall = new Hall
            {
                Name = name,
                Adress = adress,
                CityId = id
            };
            context.Halls.Add(hall);
            context.SaveChanges();
        }

        private void CreateGenre(ApplicationDbContext context, string name, int num)
        {
            var genre = new Genre
            {
                Name = name,
                CategoryId = num
            };
            context.Genres.Add(genre);
            context.SaveChanges();
        }

        private void CreateCategory(ApplicationDbContext context, string name)
        {
            var category = new Category
            {
                Name = name
            };
            context.Categories.Add(category);
            context.SaveChanges();
        }

        private void CreateCity(ApplicationDbContext context, string name)
        {
            var city = new City
            {
                Name = name
            };

            context.Cities.Add(city);
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
