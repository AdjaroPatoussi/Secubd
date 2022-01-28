namespace Secubd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Module")]
    public partial class Module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Module()
        {
            DISPENSERs = new HashSet<DISPENSER>();
            NOTERs = new HashSet<NOTER>();
        }

        [Key]
        [StringLength(10)]
        public string codeMod { get; set; }

        [StringLength(100)]
        public string nomMod { get; set; }

        public int? credit { get; set; }

        public bool? est_requis { get; set; }

        [StringLength(10)]
        public string codeNiv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISPENSER> DISPENSERs { get; set; }

        public virtual Niveau Niveau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTER> NOTERs { get; set; }
    }
}
