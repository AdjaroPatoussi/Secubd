using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Secubd.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Annee_Academique>()
                .Property(e => e.libelleAnn_Ac)
                .IsUnicode(false);

            modelBuilder.Entity<Annee_Academique>()
                .HasMany(e => e.DISPENSERs)
                .WithRequired(e => e.Annee_Academique)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Annee_Academique>()
                .HasMany(e => e.Inscrires)
                .WithRequired(e => e.Annee_Academique)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classe>()
                .Property(e => e.codeClass)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .Property(e => e.codeNiv)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .Property(e => e.libelleClass)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .HasMany(e => e.DISPENSERs)
                .WithRequired(e => e.Classe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classe>()
                .HasMany(e => e.Inscrires)
                .WithRequired(e => e.Classe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DISPENSER>()
                .Property(e => e.codeMod)
                .IsUnicode(false);

            modelBuilder.Entity<DISPENSER>()
                .Property(e => e.codeClass)
                .IsUnicode(false);

            modelBuilder.Entity<DISPENSER>()
                .Property(e => e.codeEns)
                .IsUnicode(false);

            modelBuilder.Entity<DISPENSER>()
                .Property(e => e.libelleAnn_Ac)
                .IsUnicode(false);

            modelBuilder.Entity<Enseignant>()
                .Property(e => e.codeEns)
                .IsUnicode(false);

            modelBuilder.Entity<Enseignant>()
                .Property(e => e.nomEns)
                .IsUnicode(false);

            modelBuilder.Entity<Enseignant>()
                .Property(e => e.prenomEns)
                .IsUnicode(false);

            modelBuilder.Entity<Enseignant>()
                .Property(e => e.logEns)
                .IsUnicode(false);

           

            modelBuilder.Entity<Enseignant>()
                .HasMany(e => e.DISPENSERs)
                .WithRequired(e => e.Enseignant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Etudiant>()
                .Property(e => e.numeroEtud)
                .IsUnicode(false);

            modelBuilder.Entity<Etudiant>()
                .Property(e => e.nomEtud)
                .IsUnicode(false);

            modelBuilder.Entity<Etudiant>()
                .Property(e => e.prenomEtud)
                .IsUnicode(false);

            modelBuilder.Entity<Etudiant>()
                .Property(e => e.sexe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Etudiant>()
                .Property(e => e.codePar)
                .IsUnicode(false);

          
            modelBuilder.Entity<Etudiant>()
                .HasMany(e => e.Inscrires)
                .WithRequired(e => e.Etudiant)
                .HasForeignKey(e => e.codeEtud)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Etudiant>()
                .HasMany(e => e.NOTERs)
                .WithRequired(e => e.Etudiant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.codeEval)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.libelleEval)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluation>()
                .HasMany(e => e.NOTERs)
                .WithRequired(e => e.Evaluation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inscrire>()
                .Property(e => e.codeClass)
                .IsUnicode(false);

            modelBuilder.Entity<Inscrire>()
                .Property(e => e.codeEtud)
                .IsUnicode(false);

            modelBuilder.Entity<Inscrire>()
                .Property(e => e.codeNiv)
                .IsUnicode(false);

            modelBuilder.Entity<Inscrire>()
                .Property(e => e.libelleAnn_Ac)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.codeMod)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.nomMod)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.codeNiv)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .HasMany(e => e.DISPENSERs)
                .WithRequired(e => e.Module)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Module>()
                .HasMany(e => e.NOTERs)
                .WithRequired(e => e.Module)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Niveau>()
                .Property(e => e.codeNiv)
                .IsUnicode(false);

            modelBuilder.Entity<Niveau>()
                .Property(e => e.libelleNiv)
                .IsUnicode(false);

            modelBuilder.Entity<Niveau>()
                .Property(e => e.codePar)
                .IsUnicode(false);

            modelBuilder.Entity<Niveau>()
                .HasMany(e => e.Inscrires)
                .WithRequired(e => e.Niveau)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NOTER>()
                .Property(e => e.numeroEtud)
                .IsUnicode(false);

            modelBuilder.Entity<NOTER>()
                .Property(e => e.codeMod)
                .IsUnicode(false);

            modelBuilder.Entity<NOTER>()
                .Property(e => e.codeEval)
                .IsUnicode(false);

            modelBuilder.Entity<Parcour>()
                .Property(e => e.codePar)
                .IsUnicode(false);

            modelBuilder.Entity<Parcour>()
                .Property(e => e.libellePar)
                .IsUnicode(false);
        }
    }
}
