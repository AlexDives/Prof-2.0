namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.PeopleWork")]
    public partial class PeopleWork
    {
        public int id { get; set; }

        public int idPeople { get; set; }

        [StringLength(1500)]
        public string workPlace { get; set; }

        [StringLength(1500)]
        public string doljn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEnd { get; set; }

        [Required]
        [StringLength(1)]
        public string isActual { get; set; }

        public DateTime? dateCrt { get; set; }

        [StringLength(1)]
        public string isWorked { get; set; }

        [StringLength(1)]
        public string stajObsh { get; set; }

        [StringLength(1)]
        public string stajPed { get; set; }

        [StringLength(1)]
        public string stajNPed { get; set; }

        [StringLength(1)]
        public string isSovm { get; set; }

        public virtual Person Person { get; set; }
    }
}
