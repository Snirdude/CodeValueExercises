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
        private string _reviewerName;
        private string _reviewDate;
        private bool _approved;

        public CodeReviewAttribute(string reviewerName, string reviewDate, bool isApproved)
        {
            ReviewerName = reviewerName;
            ReviewDate = reviewDate;
            Approved = isApproved;
        }

        public string ReviewerName
        {
            get
            {
                return _reviewerName;
            }
            private set
            {
                _reviewerName = value;
            }
        }

        public string ReviewDate
        {
            get
            {
                return _reviewDate;
            }
            private set
            {
                _reviewDate = value;
            }
        }

        public bool Approved
        {
            get
            {
                return _approved;
            }
            private set
            {
                _approved = value;
            }
        }
    }
}
