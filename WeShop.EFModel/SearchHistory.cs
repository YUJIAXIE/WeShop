namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SearchHistory")]
    public partial class SearchHistory
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string CusId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string SearchText { get; set; }

        public DateTime Datetime { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
