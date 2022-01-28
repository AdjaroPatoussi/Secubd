namespace Secubd.vu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("notemodeval")]
    public partial class notemodeval
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string numeroEtud { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string codeMod { get; set; }

        public bool? est_requis { get; set; }

        public double? moyN { get; set; }

        public double? moyR { get; set; }

        [StringLength(10)]
        public string codeNiv { get; set; }
    }
}
