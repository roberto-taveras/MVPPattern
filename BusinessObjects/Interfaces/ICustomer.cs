namespace BusinessObjects.Interfaces
{
    public interface ICustomer
    {        
        int Id { get; set; }
        string CustName { get; set; }
        string Adress { get; set; }
        bool Status { get; set; }
        int CustomerTypeId { get; set; }

    }
}