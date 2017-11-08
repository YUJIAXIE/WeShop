namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RevPhoto")]
    public partial class RevPhoto
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RevId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string No { get; set; }

        [StringLength(50)]
        public string ImageUrl { get; set; }

        public virtual ProReview ProReview { get; set; }
    }
}
