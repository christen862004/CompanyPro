using Microsoft.EntityFrameworkCore;

namespace CompanyPro.Models
{
    public class ITIContext:DbContext
    {
        public ITIContext():base() { }//call default

        //class inject ITIContext
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {

        }

        //Class MApping Table
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("Data Source=.;Initial Catalog=Inatke44_9M_Monf;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department { Id=1,Name="SD",ManagerName="Alaa"});
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "OS", ManagerName = "Asmaa" });
            modelBuilder.Entity<Employee>()
                .HasData(new Employee() { Id=1,Name="Ahmed",Address="Alex",Salary=1000,ImageURl="m.png",jobTitle="Engineer",DepartmentId=1});
            modelBuilder.Entity<Employee>()
                .HasData(new Employee() { Id = 2, Name = "Hala", Address = "Cairo", Salary = 2000, ImageURl = "2.jpg", jobTitle = "Engineer", DepartmentId = 2 });
            base.OnModelCreating(modelBuilder);
        }
    }
}
