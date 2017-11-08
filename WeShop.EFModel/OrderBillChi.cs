namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBillChi")]
    public partial class OrderBillChi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string ProCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UnitPrice { get; set; }

        public int? Qty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SumPrice { get; set; }

        [StringLength(1)]
        public string IsReview { get; set; }

        public virtual OrderBillFath OrderBillFath { get; set; }

        public virtual Product Product { get; set; }
    }
}
