using BusinessObjects.Context;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Resources;

namespace BusinessObjects.Presenters
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        ResourceManager resourceManager = new ResourceManager(typeof(Resources.Resource));
       
       
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerTypeId).GreaterThan(0).WithMessage( resourceManager.GetString("RequiredErrorMessage") ?? ($"El campo {nameof(Customer.CustomerTypeId)} es requerido")); 

        }

    }

    public class CustomerPresenter : RepositoryBase<ICustomer, Customer>
    {
        private readonly CustomerValidator validator = new CustomerValidator();
        public CustomerPresenter(CourseContext<Customer> context, ICustomer customer) : base(context, customer)
        {

        }
        protected override void extendedValidations()
        {
            var  validations = validator.Validate(this._entity);
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
