using BusinessObjects.Interfaces;

namespace BusinessObjects.Models
{
    public class VendorType : IVendorType
    {
        public int Id { get; set; }
        public string Description { get; set; }

    }
}
