namespace Secubd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOTER")]
    public partial class NOTER
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string numeroEtud { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string codeMod { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string codeEval { get; set; }

        public double? note { get; set; }

        public bool? valide { get; set; }

        public DateTime dateEval { get; set; }

        public virtual Etudiant Etudiant { get; set; }

        public virtual Evaluation Evaluation { get; set; }

        public virtual Module Module { get; set; }
    }
}
