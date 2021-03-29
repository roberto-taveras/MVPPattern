/*
MIT License

Copyright (c) [2020] [Jose Roberto Taveras Galvan]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

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
