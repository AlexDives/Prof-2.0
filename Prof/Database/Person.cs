namespace Prof.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prof.People")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Educations = new HashSet<Education>();
            PeopleChildrens = new HashSet<PeopleChildren>();
            PeopleDepartments = new HashSet<PeopleDepartment>();
            PeopleEncouragements = new HashSet<PeopleEncouragement>();
            PeopleLivingConditions = new HashSet<PeopleLivingCondition>();
            PeopleSocialStatus = new HashSet<PeopleSocialStatu>();
            PeopleWorks = new HashSet<PeopleWork>();
            Users = new HashSet<User>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string famil { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string otch { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        [StringLength(50)]
        public string pasp_ser { get; set; }

        [StringLength(100)]
        public string pasp_num { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pasp_date { get; set; }

        [StringLength(1500)]
        public string pasp_issue { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        [StringLength(3)]
        public string gender { get; set; }

        [StringLength(1500)]
        public string propiska { get; set; }

        [StringLength(1)]
        public string isPensioner { get; set; }

        [StringLength(50)]
        public string startTrudYearStr { get; set; }

        [StringLength(1)]
        public string isProf { get; set; }

        [StringLength(500)]
        public string numProfTicket { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEnter { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateExit { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? dateCrt { get; set; }

        [StringLength(1)]
        public string type { get; set; }

        [StringLength(1500)]
        public string activity { get; set; }

        [StringLength(1500)]
        public string socialWork { get; set; }

        [StringLength(50)]
        public string typeDoc { get; set; }

        [StringLength(1500)]
        public string hobbies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Educations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleChildren> PeopleChildrens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleDepartment> PeopleDepartments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleEncouragement> PeopleEncouragements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleLivingCondition> PeopleLivingConditions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleSocialStatu> PeopleSocialStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleWork> PeopleWorks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
