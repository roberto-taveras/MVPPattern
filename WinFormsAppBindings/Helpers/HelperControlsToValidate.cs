

using BusinessObjects.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace CommonUserControls.Helpers
{
    public class HelperControlsTranslate
    {
        Control _control;
        BusinessObjectsResourceManager _resourceManager;
        public HelperControlsTranslate(Control control, BusinessObjectsResourceManager resourceManager)
        {
            _control = control;
            _resourceManager = resourceManager;

        }

        public void Translate()
        {
            translate(_control);
        }

        void translate(Control control)
        {

            foreach (Control item in control.Controls)
            {
                if (item != null)
                {
                    Label label = item as Label;
                    if (label != null)
                    {
                        label.Text = _resourceManager.Translate(label.Name) ?? label.Text;
                        continue;
                    }

                    CheckBox checBox = item as CheckBox;
                    if (checBox != null)
                    {
                        checBox.Text = _resourceManager.Translate(checBox.Name) ?? checBox.Text;
                        continue;

                    }

                    Button button = item as Button;
                    if (button != null)
                    {
                        button.Text = _resourceManager.Translate(button.Name) ?? button.Text;
                    }
                    else
                    {
                        translate(item);
                    }

                }

            }
        }
    }
    public class HelperControlsToValidate
    {
        private ErrorProvider errorProvider1 = new ErrorProvider();
        public Dictionary<string,Control> dic = new Dictionary<string,Control>();

        public  HelperControlsToValidate(Control sender)
        {
            addControlsToDictionary(sender);
        }

        protected void addControlsToDictionary(Control sender)
        {
            foreach (Control nivelSuperior in sender.Controls)
            {
                addItemToDictionary(nivelSuperior);
                foreach (Control item in nivelSuperior.Controls)
                {
                    addItemToDictionary(item);
                    if (item.Controls != null)
                        addControlsToDictionary(item);
                }
            }
        }

        private void addItemToDictionary(Control sender)
        {
            if (sender.Tag != null)
            {

                if (!dic.ContainsKey(sender.Tag.ToString()))
                {
                    dic.Add(sender.Tag.ToString(), sender);
                }
            }
        }

        public void ValidateMembers(ICollection<ValidationResult> sender) {


            foreach (var item in sender)
            {
                foreach (var memberName in item.MemberNames)
                {
                    var found = dic.Where(a => a.Key == memberName).FirstOrDefault();
                    if (!string.IsNullOrEmpty(found.Key))
                        errorProvider1.SetError(found.Value, item.ErrorMessage);

                }

            }
        }

        public void ClearErrors(ICollection<ValidationResult> sender)
        {
            foreach (var item in dic)
            {
                 errorProvider1.SetError(item.Value, null);

            }
        }
    }
}
