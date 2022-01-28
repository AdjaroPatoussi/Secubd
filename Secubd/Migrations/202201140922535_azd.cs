namespace Secubd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class azd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annee_Academique",
                c => new
                    {
                        libelleAnn_Ac = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.libelleAnn_Ac);
            
            CreateTable(
                "dbo.DISPENSER",
                c => new
                    {
                        codeMod = c.String(nullable: false, maxLength: 10),
                        codeClass = c.String(nullable: false, maxLength: 10),
                        codeEns = c.String(nullable: false, maxLength: 128),
                        libelleAnn_Ac = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => new { t.codeMod, t.codeClass, t.codeEns, t.libelleAnn_Ac })
                .ForeignKey("dbo.Annee_Academique", t => t.libelleAnn_Ac, cascadeDelete: true)
                .ForeignKey("dbo.Classe", t => t.codeClass, cascadeDelete: true)
                .ForeignKey("dbo.Module", t => t.codeMod, cascadeDelete: true)
                .ForeignKey("dbo.Enseignant", t => t.codeEns, cascadeDelete: true)
                .Index(t => t.codeMod)
                .Index(t => t.codeClass)
                .Index(t => t.codeEns)
                .Index(t => t.libelleAnn_Ac);
            
            CreateTable(
                "dbo.Classe",
                c => new
                    {
                        codeClass = c.String(nullable: false, maxLength: 10),
                        codeNiv = c.String(maxLength: 10),
                        libelleClass = c.String(maxLength: 50),
                        capacite = c.Int(),
                    })
                .PrimaryKey(t => t.codeClass)
                .ForeignKey("dbo.Niveau", t => t.codeNiv)
                .Index(t => t.codeNiv);
            
            CreateTable(
                "dbo.Inscrire",
                c => new
                    {
                        codeClass = c.String(nullable: false, maxLength: 10),
                        codeEtud = c.String(nullable: false, maxLength: 128),
                        codeNiv = c.String(nullable: false, maxLength: 10),
                        libelleAnn_Ac = c.String(nullable: false, maxLength: 10),
                        Etudiant_numeroEtud = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => new { t.codeClass, t.codeEtud, t.codeNiv, t.libelleAnn_Ac })
                .ForeignKey("dbo.Annee_Academique", t => t.libelleAnn_Ac, cascadeDelete: true)
                .ForeignKey("dbo.Classe", t => t.codeClass, cascadeDelete: true)
                .ForeignKey("dbo.Etudiant", t => t.Etudiant_numeroEtud)
                .ForeignKey("dbo.Niveau", t => t.codeNiv, cascadeDelete: true)
                .Index(t => t.codeClass)
                .Index(t => t.codeNiv)
                .Index(t => t.libelleAnn_Ac)
                .Index(t => t.Etudiant_numeroEtud);
            
            CreateTable(
                "dbo.Etudiant",
                c => new
                    {
                        numeroEtud = c.String(nullable: false, maxLength: 10),
                        nomEtud = c.String(maxLength: 100),
                        prenomEtud = c.String(maxLength: 100),
                        sexe = c.String(maxLength: 2),
                        dateNaissance = c.DateTime(),
                        codePar = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.numeroEtud)
                .ForeignKey("dbo.Parcours", t => t.codePar)
                .Index(t => t.codePar);
            
            CreateTable(
                "dbo.NOTER",
                c => new
                    {
                        numeroEtud = c.String(nullable: false, maxLength: 10),
                        codeMod = c.String(nullable: false, maxLength: 10),
                        codeEval = c.String(nullable: false, maxLength: 10),
                        note = c.Double(),
                        valide = c.Boolean(),
                        dateEval = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.numeroEtud, t.codeMod, t.codeEval })
                .ForeignKey("dbo.Etudiant", t => t.numeroEtud, cascadeDelete: true)
                .ForeignKey("dbo.Evaluation", t => t.codeEval, cascadeDelete: true)
                .ForeignKey("dbo.Module", t => t.codeMod, cascadeDelete: true)
                .Index(t => t.numeroEtud)
                .Index(t => t.codeMod)
                .Index(t => t.codeEval);
            
            CreateTable(
                "dbo.Evaluation",
                c => new
                    {
                        codeEval = c.String(nullable: false, maxLength: 10),
                        libelleEval = c.String(maxLength: 50),
                        pourcentage = c.Double(),
                    })
                .PrimaryKey(t => t.codeEval);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        codeMod = c.String(nullable: false, maxLength: 10),
                        nomMod = c.String(maxLength: 100),
                        credit = c.Int(),
                        est_requis = c.Boolean(),
                        codeNiv = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.codeMod)
                .ForeignKey("dbo.Niveau", t => t.codeNiv)
                .Index(t => t.codeNiv);
            
            CreateTable(
                "dbo.Niveau",
                c => new
                    {
                        codeNiv = c.String(nullable: false, maxLength: 10),
                        libelleNiv = c.String(maxLength: 10),
                        nbreModule = c.Int(nullable: false),
                        codePar = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.codeNiv)
                .ForeignKey("dbo.Parcours", t => t.codePar)
                .Index(t => t.codePar);
            
            CreateTable(
                "dbo.Parcours",
                c => new
                    {
                        codePar = c.String(nullable: false, maxLength: 10),
                        libellePar = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.codePar);
            
            CreateTable(
                "dbo.Enseignant",
                c => new
                    {
                        codeEns = c.String(nullable: false, maxLength: 128),
                        nomEns = c.String(maxLength: 20),
                        prenomEns = c.String(maxLength: 20),
                        grade = c.Int(),
                        anneePriseFonction = c.DateTime(),
                        logEns = c.String(maxLength: 258),
                    })
                .PrimaryKey(t => t.codeEns);
            
          
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nomEns = c.String(maxLength: 10),
                        prenomEns = c.String(maxLength: 10),
                        grade = c.Int(),
                        anneePriseFonction = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DISPENSER", "codeEns", "dbo.Enseignant");
            DropForeignKey("dbo.NOTER", "codeMod", "dbo.Module");
            DropForeignKey("dbo.Niveau", "codePar", "dbo.Parcours");
            DropForeignKey("dbo.Etudiant", "codePar", "dbo.Parcours");
            DropForeignKey("dbo.Module", "codeNiv", "dbo.Niveau");
            DropForeignKey("dbo.Inscrire", "codeNiv", "dbo.Niveau");
            DropForeignKey("dbo.Classe", "codeNiv", "dbo.Niveau");
            DropForeignKey("dbo.DISPENSER", "codeMod", "dbo.Module");
            DropForeignKey("dbo.NOTER", "codeEval", "dbo.Evaluation");
            DropForeignKey("dbo.NOTER", "numeroEtud", "dbo.Etudiant");
            DropForeignKey("dbo.Inscrire", "Etudiant_numeroEtud", "dbo.Etudiant");
            DropForeignKey("dbo.Inscrire", "codeClass", "dbo.Classe");
            DropForeignKey("dbo.Inscrire", "libelleAnn_Ac", "dbo.Annee_Academique");
            DropForeignKey("dbo.DISPENSER", "codeClass", "dbo.Classe");
            DropForeignKey("dbo.DISPENSER", "libelleAnn_Ac", "dbo.Annee_Academique");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Niveau", new[] { "codePar" });
            DropIndex("dbo.Module", new[] { "codeNiv" });
            DropIndex("dbo.NOTER", new[] { "codeEval" });
            DropIndex("dbo.NOTER", new[] { "codeMod" });
            DropIndex("dbo.NOTER", new[] { "numeroEtud" });
            DropIndex("dbo.Etudiant", new[] { "codePar" });
            DropIndex("dbo.Inscrire", new[] { "Etudiant_numeroEtud" });
            DropIndex("dbo.Inscrire", new[] { "libelleAnn_Ac" });
            DropIndex("dbo.Inscrire", new[] { "codeNiv" });
            DropIndex("dbo.Inscrire", new[] { "codeClass" });
            DropIndex("dbo.Classe", new[] { "codeNiv" });
            DropIndex("dbo.DISPENSER", new[] { "libelleAnn_Ac" });
            DropIndex("dbo.DISPENSER", new[] { "codeEns" });
            DropIndex("dbo.DISPENSER", new[] { "codeClass" });
            DropIndex("dbo.DISPENSER", new[] { "codeMod" });
           
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
           
            DropTable("dbo.Enseignant");
            DropTable("dbo.Parcours");
            DropTable("dbo.Niveau");
            DropTable("dbo.Module");
            DropTable("dbo.Evaluation");
            DropTable("dbo.NOTER");
            DropTable("dbo.Etudiant");
            DropTable("dbo.Inscrire");
            DropTable("dbo.Classe");
            DropTable("dbo.DISPENSER");
            DropTable("dbo.Annee_Academique");
        }
    }
}
