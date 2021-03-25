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

    }

    public sealed class Singleton
    {
        private readonly static List<Languaje> _instance;

        static Singleton()
        {
            _instance = new List<Languaje>();
            _instance.Add(new Languaje() { Id = "es-DO", Description = "Español" });
            _instance.Add(new Languaje() { Id = "en-US", Description = "Ingles" });
        }

        public static List<Languaje> Instance
        {
            get
            {
                return _instance;
            }
        }
    }

}
