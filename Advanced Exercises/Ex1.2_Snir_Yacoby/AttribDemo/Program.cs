using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool? isAllApproved = new Analyzer().AnalyzeAssembly(Assembly.GetExecutingAssembly());
            if (isAllApproved != null)
            {
                Console.WriteLine(isAllApproved);
            }
            else
            {
                Console.WriteLine("Error occured");
            }
        }
    }
}
