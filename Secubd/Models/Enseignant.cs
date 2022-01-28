namespace Secubd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enseignant")]
    public partial class Enseignant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enseignant()
        {
            DISPENSERs = new HashSet<DISPENSER>();
        }

        [Key]
        [StringLength(128)]
        public string codeEns { get; set; }

        [StringLength(20)]
        public string nomEns { get; set; }

        [StringLength(20)]
        public string prenomEns { get; set; }

        public int? grade { get; set; }

        public DateTime? anneePriseFonction { get; set; }

        [StringLength(258)]
        public string logEns { get; set; }

     

       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISPENSER> DISPENSERs { get; set; }
    }
}
