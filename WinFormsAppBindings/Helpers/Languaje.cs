using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppBindings.Helpers
{
    public class Languaje
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public static List<Languaje> GetLanguajes() 
        {
            var result = new List<Languaje>();
            result.Add(new Languaje() { Id = "es-DO", Description = "Español" } );
            result.Add(new Languaje() { Id = "en-US", Description = "Ingles" });
            return result;
        }
    }


}
