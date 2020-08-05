namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.PeopleChildren")]
    public partial class PeopleChildren
    {
        public int id { get; set; }

        public int? idPeople { get; set; }

        [StringLength(250)]
        public string fioChildren { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        public DateTime? dateCrt { get; set; }

        public virtual Person Person { get; set; }
    }
}
