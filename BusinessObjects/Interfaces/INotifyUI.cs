using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Interfaces
{
    public interface INotifyUI
    {
        void ClearErrorsValidations(ICollection<ValidationResult> sender);
        void NotifyErrors(ICollection<ValidationResult> sender);
    }
}
