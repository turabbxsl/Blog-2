namespace Blogsayti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("yorum")]
    public partial class yorum
    {
        public int yorumid { get; set; }

        [Column("yorum")]
        [Required]
        [StringLength(1500)]
        public string yorum1 { get; set; }

        public int meqaleid { get; set; }

        public DateTime? eklenmetarixi { get; set; }

        [Required]
        [StringLength(150)]
        public string adsoyad { get; set; }

        public int? begenme { get; set; }

        public virtual meqale meqale { get; set; }
    }
}
