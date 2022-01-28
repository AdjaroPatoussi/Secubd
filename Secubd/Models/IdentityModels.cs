using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Secubd.vu;

namespace Secubd.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {

        

        [StringLength(10)]
        public string nomEns { get; set; }

        [StringLength(10)]
        public string prenomEns { get; set; }

        public int? grade { get; set; }

        public DateTime? anneePriseFonction { get; set; }

       
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

       

        public virtual DbSet<Annee_Academique> Annee_Academique { get; set; }
        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<DISPENSER> DISPENSERs { get; set; }
        public virtual DbSet<Enseignant> Enseignants { get; set; }
        public virtual DbSet<Etudiant> Etudiants { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<Inscrire> Inscrires { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Niveau> Niveaux { get; set; }
        public virtual DbSet<NOTER> NOTERs { get; set; }
        public virtual DbSet<Parcour> Parcours { get; set; }
        public virtual DbSet<ConsDGCh> ConsDGCh { get; set; }
        public virtual DbSet<ConsEnseignant> ConsEnseignant { get; set; }
        public virtual DbSet<ConsEnseignantAn> ConsEnseignantAn { get; set; }
        public virtual DbSet<notemodeval> notemodeval { get; set; }
        public virtual DbSet<valCh> valCh { get; set; }
        public virtual DbSet<valDg> valDg { get; set; }
        public virtual DbSet<ValEnseignant> ValEnseignant { get; set; }

        public static ApplicationDbContext Create()
        {
            
            
            return new ApplicationDbContext();
        }

        

      
    }
}