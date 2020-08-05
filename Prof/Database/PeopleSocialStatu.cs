namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.PeopleSocialStatus")]
    public partial class PeopleSocialStatu
    {
        public int id { get; set; }

        public int? idPeople { get; set; }

        public int? idTypeSocialStatus { get; set; }

        public DateTime dateCrt { get; set; }

        public virtual Person Person { get; set; }

        public virtual TypeSocialStatu TypeSocialStatu { get; set; }
    }
}
