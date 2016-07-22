using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XLinq
{
    class Helper
    {
        public IEnumerable<Type> GetAllClasses()
        {
            return Assembly.GetAssembly(typeof(string)).GetTypes().Where(c => c.IsClass && c.IsPublic);
        }
    }
}
