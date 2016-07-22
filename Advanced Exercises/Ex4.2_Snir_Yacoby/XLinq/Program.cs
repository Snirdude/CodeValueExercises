using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument root = new XDocument();
            Helper helper = new Helper();
            IEnumerable<Type> classes = helper.GetAllClasses();
            foreach (var c in classes)
            {
                var properties = c.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var methods = c.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                root.Add(new XElement(new XElement("Type", new XAttribute("Fullname", c.FullName))));
            }
        }
    }
}
