namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sort")]
    public partial class Sort
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sort()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string UpCode { get; set; }

        [StringLength(50)]
        public string SortBody { get; set; }

        [StringLength(50)]
        public string SortImgurl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
