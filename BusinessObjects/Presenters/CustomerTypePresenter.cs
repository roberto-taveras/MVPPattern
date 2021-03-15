using BusinessObjects.Context;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;
using BusinessObjects.Resources;
using System;

namespace BusinessObjects.Presenters
{
    public class CustomerTypePresenter: RepositoryBase<ICustomerType,CustomerType>
    {
        public CustomerTypePresenter(ICustomerType customerType, BusinessObjectsResourceManager businessObjectsResourceManager) : base(customerType,businessObjectsResourceManager)
        {
            _dbSet = _context.Set<CustomerType>();

            Add();

        }
    }
}
