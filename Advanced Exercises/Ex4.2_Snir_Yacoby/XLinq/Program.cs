using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using System.IO;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            var document = helper.CreateXML();
            helper.B(document);
        }
    }
}
