namespace Secubd.vu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConsEnseignant")]
    public partial class ConsEnseignant
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string numeroEtud { get; set; }

        [StringLength(201)]
        public string nomETudiant { get; set; }

        [StringLength(10)]
        public string codePar { get; set; }

        [StringLength(100)]
        public string nomMod { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime dateEval { get; set; }

        public double? note { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string codeMod { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string codeEval { get; set; }
    }
}
