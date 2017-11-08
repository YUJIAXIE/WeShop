namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProReview")]
    public partial class ProReview
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProReview()
        {
            RevPhotoes = new HashSet<RevPhoto>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string ProCode { get; set; }

        [StringLength(50)]
        public string CusId { get; set; }

        [Column(TypeName = "text")]
        public string Body { get; set; }

        [StringLength(1)]
        public string State { get; set; }

        public int? Rate { get; set; }

        public DateTime? CreateTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RevPhoto> RevPhotoes { get; set; }
    }
}
