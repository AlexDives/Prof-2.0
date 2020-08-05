namespace Prof.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("data source=91.200.160.209;initial catalog=Prof;user id=mssqlProf;password=Profmssql_748159263;MultipleActiveResultSets=True;App=EntityFramework")
            //: base("data source=ALEX-MSI\\SQLEXPRESS;initial catalog=Prof;persist security info=True;user id=mssqlProf;password=Profmssql;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public DataBase(string connectionString)
            : base(connectionString)
        {
        }
        public virtual DbSet<PeopleEducation> PeopleEducations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PeopleChildren> PeopleChildrens { get; set; }
        public virtual DbSet<PeopleDepartment> PeopleDepartments { get; set; }
        public virtual DbSet<PeopleEncouragement> PeopleEncouragements { get; set; }
        public virtual DbSet<PeopleLivingCondition> PeopleLivingConditions { get; set; }
        public virtual DbSet<PeopleSocialStatu> PeopleSocialStatus { get; set; }
        public virtual DbSet<PeopleWork> PeopleWorks { get; set; }
        public virtual DbSet<ProjectVersion> ProjectVersions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TypeEncouragement> TypeEncouragements { get; set; }
        public virtual DbSet<TypeLivingCondition> TypeLivingConditions { get; set; }
        public virtual DbSet<TypeSocialStatu> TypeSocialStatus { get; set; }
        public virtual DbSet<UserDepartment> UserDepartments { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.PeopleDepartments)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.idDepartment)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Department>()
                .HasMany(e => e.UserDepartments)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.idDepartments);

            modelBuilder.Entity<Education>()
                .Property(e => e.dateCrt)
                .HasPrecision(0);

            modelBuilder.Entity<Person>()
                .Property(e => e.dateCrt)
                .HasPrecision(0);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Educations)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.idPeople);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PeopleChildrens)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.idPeople)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PeopleDepartments)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.idPeople)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PeopleEncouragements)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.idPeople)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PeopleLivingConditions)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.idPeople)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PeopleSocialStatus)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.idPeople)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PeopleWorks)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.idPeople);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.idPeople)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.idRole);

            modelBuilder.Entity<TypeEncouragement>()
                .HasMany(e => e.PeopleEncouragements)
                .WithOptional(e => e.TypeEncouragement)
                .HasForeignKey(e => e.idTypeEncouragement)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TypeLivingCondition>()
                .HasMany(e => e.PeopleLivingConditions)
                .WithOptional(e => e.TypeLivingCondition)
                .HasForeignKey(e => e.idTypeLivingConditions)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TypeSocialStatu>()
                .HasMany(e => e.PeopleSocialStatus)
                .WithOptional(e => e.TypeSocialStatu)
                .HasForeignKey(e => e.idTypeSocialStatus)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserDepartments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.idUser);
        }
    }
}
