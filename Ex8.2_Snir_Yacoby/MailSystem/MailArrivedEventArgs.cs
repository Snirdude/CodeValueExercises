using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailArrivedEventArgs : EventArgs
    {
        private string _title;
        private string _body;

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public string Body
        {
            get
            {
                return _body;
            }
        }

        public MailArrivedEventArgs(string title, string body)
        {
            _title = title;
            _body = body;
        }
    }
}
