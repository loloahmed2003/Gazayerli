using Gazayerli_Task.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Gazayerli_Task.Startup))]
namespace Gazayerli_Task
{
    public partial class Startup
    {
        private ApplicationDbContext context=new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            MyRoles();
        }
        private void MyRoles()
        {
            //ApplicationDbContext context = new ApplicationDbContext();

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //// creating Creating Manager role    
            //if (!roleManager.RoleExists(MyCustomRoles.Admin))
            //{
            //    var role = new IdentityRole();
            //    role.Name = MyCustomRoles.Admin;
            //    roleManager.Create(role);
            //}
            //// creating Creating Employee role    
            //if (!roleManager.RoleExists(MyCustomRoles.Lawyer))
            //{
            //    var role = new IdentityRole();
            //    role.Name = MyCustomRoles.Lawyer;
            //    roleManager.Create(role);
            //}
            //// creating Creating Client role  
            //if (!roleManager.RoleExists(MyCustomRoles.Client))
            //{
            //    var role = new IdentityRole();
            //    role.Name = MyCustomRoles.Client;
            //    roleManager.Create(role);

            //}
        }

    
    }
}
