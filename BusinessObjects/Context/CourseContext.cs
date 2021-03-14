using BusinessObjects.Models;
using BusinessObjects.Resources;
using System.Data.Entity;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace BusinessObjects.Context
{
    public class CourseContext<TEntity> : DbContext
    {
       
        private string cultureName { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        
        public static CourseContext<TEntity> Factory()
        { 
          
            return new CourseContext<TEntity>("Curso");

        }

        protected CourseContext(string nameOrConnectionString, string cultureName = "es-DO") :base(nameOrConnectionString)
        {
            this.cultureName = cultureName;
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            this.Database.CommandTimeout = 180;

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
