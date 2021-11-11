namespace Blogsayti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kullanici")]
    public partial class kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kullanici()
        {
            kullanicirols = new HashSet<kullanicirol>();
            meqales = new HashSet<meqale>();
            kullanici1 = new HashSet<kullanici>();
            kullanicis = new HashSet<kullanici>();
        }

        public int kullaniciid { get; set; }

        [Required]
        [StringLength(50)]
        public string adi { get; set; }

        [Required]
        [StringLength(50)]
        public string soyadi { get; set; }

        [Required]
        [StringLength(50)]
        public string kullaniciadi { get; set; }

        [Required]
        [StringLength(50)]
        public string mailadresi { get; set; }

        public bool? cinsiyyet { get; set; }

        public DateTime? dogumtarixi { get; set; }

        public DateTime kayittarixi { get; set; }

        public string aciglama { get; set; }

        [StringLength(30)]
        public string parol { get; set; }

        public int? resmid { get; set; }

        public bool? yazar { get; set; }

        public bool? onaylandi { get; set; }

        public bool? aktif { get; set; }

        public virtual resm resm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kullanicirol> kullanicirols { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<meqale> meqales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kullanici> kullanici1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kullanici> kullanicis { get; set; }
    }
}
