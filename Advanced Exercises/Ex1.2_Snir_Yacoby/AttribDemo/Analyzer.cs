using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Analyzer
    {
        public bool? AnalyzeAssembly(Assembly assembly)
        {
            bool? isAllApproved = null;
            var allTypes = assembly?.GetTypes().Where(x => x.IsDefined(typeof(CodeReviewAttribute)));

            if (allTypes != null)
            {
                isAllApproved = true;
                foreach (var type in allTypes)
                {
                    var attributes = type.GetCustomAttributes(typeof(CodeReviewAttribute));

                    foreach (var attribute in attributes)
                    {
                        if (!(attribute as CodeReviewAttribute).Approved)
                        {
                            isAllApproved = false;
                            break;
                        }
                    }

                    if (isAllApproved == false)
                    {
                        break;
                    }
                }
            }

            return isAllApproved;
        }
    }
}
