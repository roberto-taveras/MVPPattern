
using BusinessObjects.Interfaces;
using BusinessObjects.Resources;
using System.ComponentModel.DataAnnotations;


namespace BusinessObjects.Models
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        [MaxLength(70, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        public string CustName { get; set; }
        [MaxLength(120, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }

    }
}
