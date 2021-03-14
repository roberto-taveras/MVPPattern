using BusinessObjects.Context;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;
using System;

namespace BusinessObjects.Presenters
{
    public class VendorTypePresenter : RepositoryBase<IVendorType, VendorType>
    {
     
        public VendorTypePresenter(CourseContext<VendorType> context,IVendorType vendorType) : base(context,vendorType)
        {

        }
    }
}
