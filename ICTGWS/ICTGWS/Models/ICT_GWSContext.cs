using System.Data.Entity;
using ICTGWS.Models;

namespace ICTGWS.Models
{
    public class ICTGWSContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<ICT_GWS.Models.ICT_GWSContext>());

        public ICTGWSContext() : base("name=ICTGWSContext") { }

        public DbSet<Program> Programs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<GradedWork> GradedWorks { get; set; }

    }
}
