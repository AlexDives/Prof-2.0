namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.Education")]
    public partial class Education
    {
        public int id { get; set; }

        public int? idPeople { get; set; }

        [StringLength(500)]
        public string nameUniver { get; set; }

        [StringLength(1500)]
        public string nameSpec { get; set; }

        [StringLength(1500)]
        public string nameKval { get; set; }

        [StringLength(150)]
        public string stLevel { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEduc { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? dateCrt { get; set; }

        [StringLength(50)]
        public string numDipl { get; set; }

        public virtual Person Person { get; set; }
    }
}
