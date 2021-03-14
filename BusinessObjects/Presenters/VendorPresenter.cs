using BusinessObjects.Context;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace BusinessObjects.Presenters
{
    public class VendorValidator : AbstractValidator<Vendor>
    {
        ResourceManager resourceManager = new ResourceManager(typeof(Resources.Resource));


        public VendorValidator()
        {
            RuleFor(x => x.VendorTypeId).GreaterThan(0).WithMessage(resourceManager.GetString("RequiredErrorMessage") ?? ($"El campo {nameof(Vendor.VendorTypeId)} es requerido"));

        }

    }

    public class VendorPresenter : RepositoryBase<IVendor, Vendor>
    {
        private readonly VendorValidator validator = new VendorValidator();
        public VendorPresenter(CourseContext<Vendor> context,IVendor vendor) : base(context, vendor)
        {

        }


        protected override void extendedValidations()
        {
            var validations = validator.Validate(this._entity);
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
