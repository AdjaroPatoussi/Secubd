namespace Secubd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DISPENSER")]
    public partial class DISPENSER
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string codeMod { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string codeClass { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(128)]
        public string codeEns { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string libelleAnn_Ac { get; set; }

        public virtual Annee_Academique Annee_Academique { get; set; }

        public virtual Classe Classe { get; set; }

        public virtual Enseignant Enseignant { get; set; }

        public virtual Module Module { get; set; }
    }
}
