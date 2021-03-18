using BusinessObjects.Context;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;
using BusinessObjects.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;

namespace BusinessObjects.Presenters
{
    public class VendorValidator : AbstractValidator<Vendor>
    {
        public VendorValidator(BusinessObjectsResourceManager businessObjectsResourceManager)
        {
            RuleFor(x => x.VendorTypeId).GreaterThan(0).WithMessage(businessObjectsResourceManager.Translate("RequiredErrorMessage") ?? ($"El campo {nameof(Vendor.VendorTypeId)} es requerido"));

        }

    }

    public class VendorPresenter : RepositoryBase<IVendor,Vendor>
    {
        private readonly VendorValidator _validator;
        public VendorPresenter(IVendor vendor, BusinessObjectsResourceManager businessObjectsResourceManager) : base(vendor,  businessObjectsResourceManager)
        {
            _validator = new VendorValidator(businessObjectsResourceManager);

            _dbSet = _context.Set<Vendor>();

            Add();
        }


        public override IEnumerable<Vendor> Get(string sender)
        {
            Expression<Func<Vendor, bool>> filter = (vendor) => vendor.VendName.ToLower().Contains(sender) || vendor.Adress.ToLower().Contains(sender);
            Func<IQueryable<Vendor>, IOrderedQueryable<Vendor>> orderFunc = orderByName => orderByName.OrderBy(vend => vend.VendName);
            return this.Get(filter, orderFunc).Select(a => new Vendor { Id = a.Id, VendName = a.VendName, Adress = a.Adress, VendorType = a.VendorType, Status = a.Status }).ToList();
        }

     
        protected override void extendedValidations()
        {
            var validations = _validator.Validate(this._entity);
            if (!validations.IsValid)
            {
                foreach (var item in validations.Errors)
                {
                    var fields = new List<string>();
                    fields.Add(item.PropertyName);
                    ValidationResult validation = new ValidationResult(item.ErrorMessage, fields);
                    this._validationResult.Add(validation);

                }
            }

        }
    }
}
