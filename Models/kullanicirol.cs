namespace Blogsayti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kullanicirol")]
    public partial class kullanicirol
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kullanicirolid { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rolid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int kullaniciid { get; set; }

        public virtual kullanici kullanici { get; set; }

        public virtual Roll Roll { get; set; }
    }
}
