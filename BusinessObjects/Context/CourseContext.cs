using BusinessObjects.Models;
using System.Data.Entity;

namespace BusinessObjects.Context
{
    public class CourseContext<TEntity> : DbContext
    {
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public static CourseContext<TEntity> Factory()
        { 
            return new CourseContext<TEntity>("Curso");

        }
       
        protected CourseContext(string nameOrConnectionString):base(nameOrConnectionString)
        {


        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Vendor>().ToTable("Vendors");
            modelBuilder.Entity<CustomerType>().ToTable("CustomerTypes");
            modelBuilder.Entity<VendorType>().ToTable("VendorTypes");

            base.OnModelCreating(modelBuilder);

        }
        //public virtual DbSet<Customer> Customers { get; set; }
       
    }
}
