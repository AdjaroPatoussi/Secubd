namespace Secubd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inscrire")]
    public partial class Inscrire
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string codeClass { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(128)]
        public string codeEtud { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string codeNiv { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string libelleAnn_Ac { get; set; }

        public virtual Annee_Academique Annee_Academique { get; set; }

        public virtual Classe Classe { get; set; }

        public virtual Etudiant Etudiant { get; set; }

        public virtual Niveau Niveau { get; set; }
    }
}
