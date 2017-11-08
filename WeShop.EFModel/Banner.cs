namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [StringLength(50)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Memo { get; set; }

        public int? PostUserId { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
