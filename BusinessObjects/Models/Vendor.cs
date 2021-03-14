using BusinessObjects.Interfaces;
using BusinessObjects.Resources;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public class Vendor : IVendor
    {
        public int Id { get; set; }
        [MaxLength(70, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        public string VendName { get; set; }
        [MaxLength(120, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int VendorTypeId { get; set; }
        public virtual VendorType VendorType { get; set; }
    }
}
