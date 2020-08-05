namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.PeopleEncouragement")]
    public partial class PeopleEncouragement
    {
        public int id { get; set; }

        public int? idPeople { get; set; }

        public int? idTypeEncouragement { get; set; }

        [StringLength(150)]
        public string source { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEncouragement { get; set; }

        public DateTime? dateCrt { get; set; }

        public double? countMat { get; set; }

        public virtual Person Person { get; set; }

        public virtual TypeEncouragement TypeEncouragement { get; set; }
    }
}
