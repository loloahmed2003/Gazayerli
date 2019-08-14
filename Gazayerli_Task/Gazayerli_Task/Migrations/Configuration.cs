namespace Gazayerli_Task.Migrations
{
    using Gazayerli_Task.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gazayerli_Task.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gazayerli_Task.Models.ApplicationDbContext context)
        {
            //if(!context.Roles.Any(r=> r.Name == MyCustomRoles.Admin))
            //{
            //    context.Roles.Add(new IdentityRole(MyCustomRoles.Admin));
            //}

            //if (!context.Roles.Any(r => r.Name == MyCustomRoles.Lawyer))
            //{
            //    context.Roles.Add(new IdentityRole(MyCustomRoles.Lawyer));
            //}

            //if (!context.Roles.Any(r => r.Name == MyCustomRoles.Client))
            //{
            //    context.Roles.Add(new IdentityRole(MyCustomRoles.Client));
            //}

            //if(! context.Users.Any(u => u.UserName == "admin@gmail.com"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);

            //    var user = new ApplicationUser()
            //    {
            //        Email = "admin@gmail.com",
            //        UserName = "admin@gmail.com"
            //    };

            //    manager.Create(user, "P@ssw0rd");
            //    manager.AddToRole(user.Id, MyCustomRoles.Admin);
            //}
        }
    }
}
