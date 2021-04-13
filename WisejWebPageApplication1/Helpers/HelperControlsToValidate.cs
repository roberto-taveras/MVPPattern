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


using BusinessObjects.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using Wisej.Web;

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
            Form form = _control as Form;
            if (form != null)
            {
                form.Text = _resourceManager.Translate(form.Name) ?? form.Text;

            }

            Page page = _control as Page;
            if (form != null)
            {
                page.Text = _resourceManager.Translate(page.Name) ?? page.Text;

            }
            translate(_control);
        }



        void translate(MenuItem control) 
        {
            control.Text = _resourceManager.Translate(control.Name) ?? control.Text;
            foreach (MenuItem item in control.MenuItems)
            {
                item.Text = _resourceManager.Translate(item.Name) ?? item.Text;
                
            }
        }
        void translate(MenuBar control) 
        {
            foreach (MenuItem item in control.MenuItems)
            {
                if (item != null)
                {
                    item.Text = _resourceManager.Translate(item.Name) ?? item.Text;
                    foreach (MenuItem x in item.MenuItems)
                    {
                        translate(x);

                    }


                }
            }
        }



        void translate(Control control)
        {

            foreach (Control item in control.Controls)
            {
                if (item != null)
                {



                    MenuBar menuBar = item as MenuBar;
                    if (menuBar != null)
                    {
                        menuBar.Text = _resourceManager.Translate(menuBar.Name) ?? menuBar.Text;
                        translate(menuBar);
                        continue;
                    }

                    Label label = item as Label;
                    if (label != null)
                    {
                        label.Text = _resourceManager.Translate(label.Name) ?? label.Text;
                        continue;
                    }

                    TextBox textbox = item as TextBox;
                    if (textbox != null)
                    {
                        textbox.Label.Text = _resourceManager.Translate(textbox.Name) ?? textbox.Label.Text;
                        continue;
                    }



                    ComboBox comboBox = item as ComboBox;
                    if (comboBox != null)
                    {
                        comboBox.Label.Text = _resourceManager.Translate(comboBox.Name) ?? comboBox.Label.Text;
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
                        continue;
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
