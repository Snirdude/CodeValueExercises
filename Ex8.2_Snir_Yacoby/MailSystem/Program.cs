using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager manager = new MailManager();
            manager.MailArrived += Manager_MailArrived;
            manager.SimulateMailArrived(null);

            TimerCallback tcb = manager.SimulateMailArrived;
            Timer timer = new Timer(tcb, null, 1000, 1000);
            Thread.Sleep(10000);
        }

        private static void Manager_MailArrived(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine("Title: " + e.Title);
            Console.WriteLine("Body: " + e.Body);
        }
    }
}
