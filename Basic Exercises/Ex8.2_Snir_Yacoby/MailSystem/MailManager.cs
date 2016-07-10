using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        protected virtual void OnMailArrived(MailArrivedEventArgs e)
        {
            MailArrived(this, e);
        }

        public void SimulateMailArrived(object state)
        {
            OnMailArrived(new MailArrivedEventArgs("Hello", "My name is Snir"));
        }
    }
}
