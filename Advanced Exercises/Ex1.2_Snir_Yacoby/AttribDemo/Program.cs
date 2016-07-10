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
            Console.WriteLine(new Program().AnalyzeAssembly(Assembly.GetExecutingAssembly()));
        }

        private bool AnalyzeAssembly(Assembly assembly)
        {
            bool isAllApproved = true;
            var allTypes = assembly?.GetTypes().Where(x => x.IsDefined(typeof(CodeReviewAttribute)));

            if(allTypes != null)
            {
                foreach (var type in allTypes)
                {
                    var attributes = type.GetCustomAttributes(typeof(CodeReviewAttribute));

                    foreach (var attribute in attributes)
                    {
                        if (!(attribute as CodeReviewAttribute).Approved)
                        {
                            isAllApproved = false;
                        }
                    }
                }
            }

            return isAllApproved;
        }
    }
}
