using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LINQ_to_Objects
{
    static class ObjectExtensions
    {
        public static void CopyTo(this object source, object destination)
        {
            var srcProperties = source.GetType().GetProperties().Where(x => x.CanRead && x.GetMethod.IsPublic);
            var dstProperties = destination.GetType().GetProperties().Where(x => x.CanWrite && x.SetMethod.IsPublic);

            foreach(var property in dstProperties)
            {
                foreach (var srcProperty in srcProperties)
                {
                    if(property.PropertyType.Equals(srcProperty.PropertyType) && property.Name == srcProperty.Name)
                    {
                        var type = srcProperty.PropertyType;
                        property.SetValue(destination, srcProperty.GetValue(source));
                    }
                }
            }
        }
    }
}
