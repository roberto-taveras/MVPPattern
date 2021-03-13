using BusinessObjects.Interfaces;
namespace BusinessObjects.Models
{
    public class Vendor : IVendor
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int VendorTypeId { get; set; }
    }
}
