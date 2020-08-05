namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.UserRole")]
    public partial class UserRole
    {
        public int id { get; set; }

        public int idUser { get; set; }

        public int idRole { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
