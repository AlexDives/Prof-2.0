namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.ProjectVersion")]
    public partial class ProjectVersion
    {
        public int id { get; set; }

        [StringLength(5)]
        public string version { get; set; }

        [StringLength(500)]
        public string ftpPath { get; set; }

        [StringLength(4000)]
        public string updText { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateUpdate { get; set; }

        [StringLength(1)]
        public string isUse { get; set; }
    }
}
