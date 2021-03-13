using BusinessObjects.Context;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;

namespace BusinessObjects.Presenters
{
    public class CustomerTypePresenter: RepositoryBase<ICustomerType, CustomerType>
    {
        public CustomerTypePresenter(ICustomerType customerType) : base(customerType)
        {

        }
    }
}
