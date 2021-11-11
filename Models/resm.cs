namespace Blogsayti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("resm")]
    public partial class resm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public resm()
        {
            kullanicis = new HashSet<kullanici>();
            meqales = new HashSet<meqale>();
        }

        [Key]
        public int resimid { get; set; }

        [StringLength(250)]
        public string kicikolculu { get; set; }

        [StringLength(250)]
        public string ortaolculu { get; set; }

        [StringLength(250)]
        public string boyukolculu { get; set; }

        public int? meqaleid { get; set; }

        [StringLength(500)]
        public string video { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kullanici> kullanicis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<meqale> meqales { get; set; }

        public virtual meqale meqale { get; set; }
    }
}
