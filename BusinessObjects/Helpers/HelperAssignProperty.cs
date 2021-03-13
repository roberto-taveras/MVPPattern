using System;
using System.Linq;

namespace BusinessObjects.Helpers
{
    public class HelperAssignProperty<T,U>  
    {
           public void AssingnProperty(string instanceToSet,string instanceFrom, T toSet, U fromSet) {
            var propertiestToSet = typeof(T).GetProperties();
            var propertiestFromSet = typeof(U).GetProperties();

            foreach (var p in propertiestToSet)
            {
                var result = propertiestFromSet.Where(k => k.Name == p.Name).FirstOrDefault();
                if (result == null)
                    throw new InvalidCastException($"La propiedad {p.Name} verifique la instancia {instanceFrom} !!");

                if(p.GetType() !=  result.GetType())
                    throw new InvalidCastException($"La propiedad {p.Name} y  la instancia {instanceFrom} tienen tipos de datos diferentes !!");

                try
                {
                    p.SetValue(toSet, result.GetValue(fromSet,null), null);
                }
                catch (Exception ex)
                {

                    throw new Exception($"Hay un error de tipos con la propiedad {p.Name}  verifique {instanceToSet} y {instanceFrom} Exception {ex.Message}" );
                }
              
            }
        }

    }
}

