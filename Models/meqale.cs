namespace Blogsayti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("meqale")]
    public partial class meqale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public meqale()
        {
            resms = new HashSet<resm>();
            yorums = new HashSet<yorum>();
            etikets = new HashSet<etiket>();
        }

        public int meqaleid { get; set; }

        [Required]
        [StringLength(100)]
        public string baslig { get; set; }

        [Required]
        public string icerik { get; set; }

        public DateTime eklenmetarixi { get; set; }

        public int kategoriyaid { get; set; }

        public int goruntulenmesayi { get; set; }

        public int begenme { get; set; }

        public int yazarid { get; set; }

        public int? resmid { get; set; }

        public virtual kategoriya kategoriya { get; set; }

        public virtual kullanici kullanici { get; set; }

        public virtual resm resm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resm> resms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yorum> yorums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<etiket> etikets { get; set; }
    }
}
