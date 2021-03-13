using BusinessObjects.Models;

namespace BusinessObjects.Interfaces
{
    public interface IVendor
    {        
        int Id { get; set; }
        string CustName { get; set; }
        string Adress { get; set; }
        bool Status { get; set; }
        int VendorTypeId { get; set; }
        VendorType VendorType { get; set; }

    }
}