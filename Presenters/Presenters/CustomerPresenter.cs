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
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;

namespace BusinessObjects.Presenters
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
       
       
        public CustomerValidator(BusinessObjectsResourceManager businessObjectsResourceManager)
        {
            RuleFor(x => x.CustomerTypeId).GreaterThan(0).WithMessage(businessObjectsResourceManager.Translate("RequiredErrorMessage") ?? ($"El campo {nameof(Customer.CustomerTypeId)} es requerido")); 

        }

    }

    public class CustomerPresenter : RepositoryBase<ICustomer,Customer>
    {
        private readonly CustomerValidator _validator;
        public CustomerPresenter(ICustomer customer, BusinessObjectsResourceManager businessObjectsResourceManager) : base( customer, businessObjectsResourceManager)
        {
            _validator = new CustomerValidator(businessObjectsResourceManager);

            _dbSet = _context.Set<Customer>();

            Add();


        }
        protected override void extendedValidations()
        {
            var  validations = _validator.Validate(this._entity);
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

        public  override IEnumerable<Customer> Get(string sender) 
        {
            Expression<Func<Customer, bool>> filter = (customer) => customer.CustName.ToLower().Contains(sender) || customer.Adress.ToLower().Contains(sender);
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderFunc = orderByName => orderByName.OrderBy(cust => cust.CustName);
            return this.Get(filter, orderFunc).Select(a => new  Customer {Id=  a.Id, CustName= a.CustName,Adress=  a.Adress, CustomerType = a.CustomerType,Status=  a.Status }).ToList();
        }

    }    
}
