namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.PeopleHobby")]
    public partial class PeopleHobby
    {
        public int id { get; set; }

        public int? idPeople { get; set; }

        [StringLength(1500)]
        public string name { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? dateCrt { get; set; }

        public virtual Person Person { get; set; }
    }
}
