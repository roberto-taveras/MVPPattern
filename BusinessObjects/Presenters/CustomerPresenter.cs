using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;
using System;

namespace BusinessObjects.Presenters
{
    public class CustomerPresenter : RepositoryBase<ICustomer, Customer>
    {
        public CustomerPresenter(ICustomer customer):base(customer)
        {

        }
  
    }
}
