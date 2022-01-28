namespace Secubd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Etudiant")]
    public partial class Etudiant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Etudiant()
        {
            Inscrires = new HashSet<Inscrire>();
            NOTERs = new HashSet<NOTER>();
        }

        [Key]
        [StringLength(10)]
        public string numeroEtud { get; set; }

        [StringLength(100)]
        public string nomEtud { get; set; }

        [StringLength(100)]
        public string prenomEtud { get; set; }

        [StringLength(2)]
        public string sexe { get; set; }

        public DateTime? dateNaissance { get; set; }

        [StringLength(10)]
        public string codePar { get; set; }

      

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inscrire> Inscrires { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTER> NOTERs { get; set; }

        public virtual Parcour Parcour { get; set; }
    }
}
