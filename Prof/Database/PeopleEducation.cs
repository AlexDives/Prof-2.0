namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PeopleEducation")]
    public partial class PeopleEducation
    {
        public int id { get; set; }

        [StringLength(150)]
        public string typeEduc { get; set; }

        [StringLength(1500)]
        public string educName { get; set; }

        [StringLength(1500)]
        public string specName { get; set; }

        [StringLength(1500)]
        public string kvalName { get; set; }

        [StringLength(100)]
        public string serAndNumDocEduc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEduc { get; set; }
    }
}
