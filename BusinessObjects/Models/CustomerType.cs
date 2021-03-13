using BusinessObjects.Interfaces;

namespace BusinessObjects.Models
{
    public class CustomerType : ICustomerType
    {
        public int Id { get; set; }
        public string Description { get; set; }

    }
}
