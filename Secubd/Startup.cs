using Microsoft.Owin;
using Owin;
using Secubd.Models;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Secubd.Startup))]
namespace Secubd
{

        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
                UserAndRole();
            }

            public void UserAndRole()
            {
                var db = new ApplicationDbContext();

                //Déclaration des rôles
                if (!db.Roles.Any(x => x.Name == roleUtilisateur.adminRole))
                {
                    db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(roleUtilisateur.adminRole));
                    db.SaveChanges();
                }

                if (!db.Roles.Any(x => x.Name == roleUtilisateur.ChargeRole))
                {
                    db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(roleUtilisateur.ChargeRole));
                    db.SaveChanges();
                }

                if (!db.Roles.Any(x => x.Name == roleUtilisateur.enseignantRole))
                {
                    db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(roleUtilisateur.enseignantRole));
                    db.SaveChanges();
                }

                if (!db.Roles.Any(x => x.Name == roleUtilisateur.directeurRole))
                {
                    db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(roleUtilisateur.directeurRole));
                    db.SaveChanges();
                }
            }
        }
    }

