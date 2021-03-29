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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessObjects.Resources
{
    public class BusinessObjectsResourceManager
    {
        string _cultureName;
        ResourceManager _resourceManager;
        public string CultureName{ get { return _cultureName; } }
        public ResourceManager ResourceManager { get { return _resourceManager; } }
        public BusinessObjectsResourceManager(string cultureName = "es-DO")
        {
            this._cultureName = cultureName;
            CultureInfo culture = CultureInfo.CreateSpecificCulture(_cultureName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            _resourceManager = new ResourceManager(typeof(Resources.Resource));
            Resource.Culture = culture;
        }
        private BusinessObjectsResourceManager()
        {

        }

        public string Translate(string sender) 
        {
            return (ResourceManager.GetString(sender, Resource.Culture));
        }

    }
}
