
using BusinessObjects.Interfaces;
namespace BusinessObjects.Models
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }

    }
}
