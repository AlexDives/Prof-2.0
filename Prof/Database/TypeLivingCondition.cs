namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.TypeLivingConditions")]
    public partial class TypeLivingCondition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeLivingCondition()
        {
            PeopleLivingConditions = new HashSet<PeopleLivingCondition>();
        }

        public int id { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleLivingCondition> PeopleLivingConditions { get; set; }
    }
}
