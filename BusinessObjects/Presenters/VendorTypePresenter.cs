using BusinessObjects.Context;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;
using BusinessObjects.Resources;
using System;
using System.Collections.Generic;

namespace BusinessObjects.Presenters
{
    public class VendorTypePresenter : RepositoryBase<IVendorType,VendorType>
    {
     
        public VendorTypePresenter(IVendorType vendorType, BusinessObjectsResourceManager  businessObjectsResourceManager) : base(vendorType,businessObjectsResourceManager)
        {
            _dbSet = _context.Set<VendorType>();

            Add();
        }

        public override IEnumerable<VendorType> Get(string sender)
        {
            throw new NotImplementedException();
        }
    }
}
