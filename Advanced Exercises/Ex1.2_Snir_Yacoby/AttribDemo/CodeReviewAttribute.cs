using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
    sealed class CodeReviewAttribute : Attribute
    {
        public CodeReviewAttribute(string reviewerName, DateTime reviewDate, bool isApproved)
        {
            ReviewerName = reviewerName;
            ReviewDate = reviewDate;
            Approved = isApproved;
        }

        public string ReviewerName { get; private set; }
        public DateTime ReviewDate { get; private set; }
        public bool Approved { get; private set; }
        
    }
}
