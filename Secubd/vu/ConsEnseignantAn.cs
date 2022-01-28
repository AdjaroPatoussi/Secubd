using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Secubd.vu
{
    
    [Table("ConsEnseignantAn")]
    public class ConsEnseignantAn
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

        [StringLength(21)]
        public string nomEnseignant { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string codeEval { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(128)]
        public string codeEns { get; set; }

        [StringLength(50)]
        public string libelleEval { get; set; }
        [StringLength(258)]
        public string logEns { get; set; }
    }
}