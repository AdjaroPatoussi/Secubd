namespace Secubd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Niveau")]
    public partial class Niveau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Niveau()
        {
            Classes = new HashSet<Classe>();
            Inscrires = new HashSet<Inscrire>();
            Modules = new HashSet<Module>();
        }

        [Key]
        [StringLength(10)]
        public string codeNiv { get; set; }

        [StringLength(10)]
        public string libelleNiv { get; set; }

        public int nbreModule { get; set; }

        [StringLength(10)]
        public string codePar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classe> Classes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inscrire> Inscrires { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Module> Modules { get; set; }

        public virtual Parcour Parcour { get; set; }
    }
}
