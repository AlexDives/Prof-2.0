namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.PeopleDepartment")]
    public partial class PeopleDepartment
    {
        public int id { get; set; }

        public int? idPeople { get; set; }

        public int? idDepartment { get; set; }

        public DateTime? dateCrt { get; set; }

        public virtual Department Department { get; set; }

        public virtual Person Person { get; set; }
    }
}
