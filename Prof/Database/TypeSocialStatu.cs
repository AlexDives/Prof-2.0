namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.TypeSocialStatus")]
    public partial class TypeSocialStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeSocialStatu()
        {
            PeopleSocialStatus = new HashSet<PeopleSocialStatu>();
        }

        public int id { get; set; }

        [StringLength(150)]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleSocialStatu> PeopleSocialStatus { get; set; }
    }
}
