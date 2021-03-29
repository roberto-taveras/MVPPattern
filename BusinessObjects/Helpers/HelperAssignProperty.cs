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
                //Veficando si p tiene get and set publicos
                bool isPublic = p.GetSetMethod() != null;
                if (!isPublic)
                    continue;

                var result = propertiestFromSet.Where(k => k.Name == p.Name ).FirstOrDefault();
                if (result == null)
                    throw new InvalidCastException($"La propiedad {p.Name} de {instanceToSet} no existe en {instanceFrom} ..!!");

                if(p.GetType() !=  result.GetType())
                    throw new InvalidCastException($"La propiedad {p.Name} {instanceToSet} tiene un tipo de dato { p.GetType()} y {instanceFrom} tiene un tipo de dato {result.GetType()}  {instanceFrom} ..!!");

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

