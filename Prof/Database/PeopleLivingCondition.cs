namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.PeopleLivingConditions")]
    public partial class PeopleLivingCondition
    {
        public int id { get; set; }

        public int? idPeople { get; set; }

        public int? idTypeLivingConditions { get; set; }

        public virtual Person Person { get; set; }

        public virtual TypeLivingCondition TypeLivingCondition { get; set; }
    }
}
