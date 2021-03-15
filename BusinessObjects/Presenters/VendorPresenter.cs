using BusinessObjects.Context;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;
using BusinessObjects.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public VendorPresenter(CourseContext<Vendor> context,IVendor vendor, BusinessObjectsResourceManager businessObjectsResourceManager) : base(context, vendor,  businessObjectsResourceManager)
        {
            _validator = new VendorValidator(businessObjectsResourceManager);
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
