namespace Secubd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evaluation")]
    public partial class Evaluation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evaluation()
        {
            NOTERs = new HashSet<NOTER>();
        }

        [Key]
        [StringLength(10)]
        public string codeEval { get; set; }

        [StringLength(50)]
        public string libelleEval { get; set; }

        public double? pourcentage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTER> NOTERs { get; set; }
    }
}
