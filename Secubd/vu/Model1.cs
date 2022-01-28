using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Secubd.vu
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ConsDGCh> ConsDGCh { get; set; }
        public virtual DbSet<ConsEnseignant> ConsEnseignant { get; set; }
        public virtual DbSet<notemodeval> notemodeval { get; set; }
        public virtual DbSet<valCh> valCh { get; set; }
        public virtual DbSet<ValEnseignant> ValEnseignant { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsDGCh>()
                .Property(e => e.numeroEtud)
                .IsUnicode(false);

            modelBuilder.Entity<ConsDGCh>()
                .Property(e => e.nomETudiant)
                .IsUnicode(false);

            modelBuilder.Entity<ConsDGCh>()
                .Property(e => e.codePar)
                .IsUnicode(false);

            modelBuilder.Entity<ConsDGCh>()
                .Property(e => e.nomMod)
                .IsUnicode(false);

            modelBuilder.Entity<ConsDGCh>()
                .Property(e => e.codeMod)
                .IsUnicode(false);

            modelBuilder.Entity<ConsDGCh>()
                .Property(e => e.codeEval)
                .IsUnicode(false);

            modelBuilder.Entity<ConsEnseignant>()
                .Property(e => e.numeroEtud)
                .IsUnicode(false);

            modelBuilder.Entity<ConsEnseignant>()
                .Property(e => e.nomETudiant)
                .IsUnicode(false);

            modelBuilder.Entity<ConsEnseignant>()
                .Property(e => e.codePar)
                .IsUnicode(false);

            modelBuilder.Entity<ConsEnseignant>()
                .Property(e => e.nomMod)
                .IsUnicode(false);

            modelBuilder.Entity<ConsEnseignant>()
                .Property(e => e.codeMod)
                .IsUnicode(false);

            modelBuilder.Entity<ConsEnseignant>()
                .Property(e => e.codeEval)
                .IsUnicode(false);

            modelBuilder.Entity<notemodeval>()
                .Property(e => e.numeroEtud)
                .IsUnicode(false);

            modelBuilder.Entity<notemodeval>()
                .Property(e => e.codeMod)
                .IsUnicode(false);

            modelBuilder.Entity<notemodeval>()
                .Property(e => e.codeNiv)
                .IsUnicode(false);

            modelBuilder.Entity<valCh>()
                .Property(e => e.numeroEtud)
                .IsUnicode(false);

            modelBuilder.Entity<valCh>()
                .Property(e => e.nomETudiant)
                .IsUnicode(false);

            modelBuilder.Entity<valCh>()
                .Property(e => e.codePar)
                .IsUnicode(false);

            modelBuilder.Entity<valCh>()
                .Property(e => e.nomMod)
                .IsUnicode(false);

            modelBuilder.Entity<valCh>()
                .Property(e => e.codeMod)
                .IsUnicode(false);

            modelBuilder.Entity<valCh>()
                .Property(e => e.codeEval)
                .IsUnicode(false);

            modelBuilder.Entity<ValEnseignant>()
                .Property(e => e.numeroEtud)
                .IsUnicode(false);

            modelBuilder.Entity<ValEnseignant>()
                .Property(e => e.nomETudiant)
                .IsUnicode(false);

            modelBuilder.Entity<ValEnseignant>()
                .Property(e => e.codePar)
                .IsUnicode(false);

            modelBuilder.Entity<ValEnseignant>()
                .Property(e => e.nomMod)
                .IsUnicode(false);

            modelBuilder.Entity<ValEnseignant>()
                .Property(e => e.codeMod)
                .IsUnicode(false);

            modelBuilder.Entity<ValEnseignant>()
                .Property(e => e.nomEnseignant)
                .IsUnicode(false);

            modelBuilder.Entity<ValEnseignant>()
                .Property(e => e.codeEval)
                .IsUnicode(false);
        }
    }
}
