using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Helper
    {
        public XDocument CreateXML()
        {
            XDocument document = new XDocument();
            XElement root = new XElement("Classes");
            document.Add(root);
            var classes = Assembly.GetAssembly(typeof(string)).GetTypes().Where(c => c.IsClass && c.IsPublic);

            foreach (var c in classes)
            {
                var properties = c.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var methods = c.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                var typeElement = new XElement("Type", new XAttribute("Fullname", c.FullName));
                var propertiesElement = new XElement("Properties");
                var methodsElement = new XElement("Methods");
                foreach (var property in properties)
                {
                    propertiesElement.Add(new XElement("Property", new XAttribute("Name", property.Name), new XAttribute("Type", property.PropertyType)));
                }

                typeElement.Add(propertiesElement);
                foreach (var method in methods)
                {
                    if (c.GetMethods(BindingFlags.DeclaredOnly).Contains(method))
                    {
                        continue;
                    }

                    var parameters = method.GetParameters();
                    var parametersElement = new XElement("Parameters");
                    var methodElement = new XElement("Method", new XAttribute("Name", method.Name), new XAttribute("ReturnType", method.ReturnType));
                    foreach (var parameter in parameters)
                    {
                        parametersElement.Add(new XElement("Parameter", new XAttribute("Name", parameter.Name), new XAttribute("Type", parameter.ParameterType)));
                    }
                    methodElement.Add(parametersElement);
                    methodsElement.Add(methodElement);
                }
                typeElement.Add(methodsElement);
                root.Add(typeElement);
            }

            document.Save("Classes.xml");

            return document;
        }

        public void A(XDocument document)
        {
            var noPropTypes = from d in document.Descendants("Type")
                              where !d.Descendants("Property").Any()
                              orderby d.Attribute("Fullname").Value
                              select d.Attribute("Fullname").Value;
            foreach (var type in noPropTypes)
            {
                Console.WriteLine(type);
            }
            Console.WriteLine(noPropTypes.Count());
        }

        public void B(XDocument document)
        {
            var methodsCount = document.Descendants("Method").Count();
            Console.WriteLine(methodsCount);
        }

        public void C(XDocument document)
        {
            var propertiesCount = document.Descendants("Property").Count();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            var propertyGroup = from p in document.Descendants("Parameter")
                                group p by p.Attribute("Type");
        }
    }
}
