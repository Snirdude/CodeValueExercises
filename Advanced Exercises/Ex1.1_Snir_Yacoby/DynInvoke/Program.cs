using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DynInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            InvokeHello(a, "Snir");
            InvokeHello(b, "Snir");
            InvokeHello(c, "Snir");
        }

        static void InvokeHello(object obj, string str)
        {
            object[] args = new string[1] { str };
            string str2 = obj?.GetType().InvokeMember("Hello", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance, null, obj, args).ToString();
            Console.WriteLine(str2);
        }
    }
}
