using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BusinessObjects.Interfaces
{
    public interface INotifyUI
    {
        void ClearErrorsValidations(ICollection<ValidationResult> sender);
        void NotifyErrors(ICollection<ValidationResult> sender);
    }
}
