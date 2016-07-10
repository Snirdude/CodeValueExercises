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
        }

        private bool AnalyzeAssembly(Assembly assembly)
        {
            bool isAllApproved = true;
            var allTypes = assembly.GetTypes().Where(x => x.IsDefined(typeof(CodeReviewAttribute)));

            foreach(var type in allTypes)
            {
                if(!(type.GetCustomAttribute(typeof(CodeReviewAttribute)) as CodeReviewAttribute).Approved)
                {
                    isAllApproved = false;
                }
            }

            return isAllApproved;
        }
    }
}
