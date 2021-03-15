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
        public string Translate(string sender) 
        {
            return (ResourceManager.GetString(sender, Resource.Culture) ?? sender).Trim();
        }

    }
}
