namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.UserDepartment")]
    public partial class UserDepartment
    {
        public int id { get; set; }

        public int idUser { get; set; }

        public int idDepartments { get; set; }

        public virtual Department Department { get; set; }

        public virtual User User { get; set; }
    }
}
