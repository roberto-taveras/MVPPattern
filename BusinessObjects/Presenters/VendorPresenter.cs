using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;

namespace BusinessObjects.Presenters
{
    public class VendorPresenter : RepositoryBase<IVendor, Vendor>
    {
        public VendorPresenter(IVendor vendor) : base(vendor)
        {

        }
    }
}
