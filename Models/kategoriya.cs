namespace Blogsayti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kategoriya")]
    public partial class kategoriya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kategoriya()
        {
            meqales = new HashSet<meqale>();
        }

        public int kategoriyaid { get; set; }

        [Required]
        [StringLength(50)]
        public string adi { get; set; }

        [StringLength(500)]
        public string aciglama { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<meqale> meqales { get; set; }
    }
}
