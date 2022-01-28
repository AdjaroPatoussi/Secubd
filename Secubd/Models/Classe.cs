namespace Secubd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Classe")]
    public partial class Classe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Classe()
        {
            DISPENSERs = new HashSet<DISPENSER>();
            Inscrires = new HashSet<Inscrire>();
        }

        [Key]
        [StringLength(10)]
        public string codeClass { get; set; }

        [StringLength(10)]
        public string codeNiv { get; set; }

        [StringLength(50)]
        public string libelleClass { get; set; }

        public int? capacite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISPENSER> DISPENSERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inscrire> Inscrires { get; set; }

        public virtual Niveau Niveau { get; set; }
    }
}
