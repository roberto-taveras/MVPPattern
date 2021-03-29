/*
MIT License

Copyright (c) [2020] [Jose Roberto Taveras Galvan]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

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
