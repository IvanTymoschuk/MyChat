using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFTestConsole.ServiceReference1;

namespace WCFTestConsole
{

    class CallBackHandler : IMessageCallback
    {
        public void GetMessage(MessageDTO msg)
        {
            Console.WriteLine(msg.Body);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MessageClient message = new MessageClient(new InstanceContext(new CallBackHandler()));
            message.SendMessage("asd", null, null, null);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
