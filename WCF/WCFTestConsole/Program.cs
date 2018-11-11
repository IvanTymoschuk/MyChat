using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFTestConsole.ServiceReference1;

namespace WCFTestConsole
{

    public class CallBackHandler : WCFTestConsole.ServiceReference1.IUserCallback, IMessageCallback, IRoomCallback
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
            try
            {
                CallBackHandler callBackHandler = new CallBackHandler();
                UserClient userClient = new UserClient(new InstanceContext(callBackHandler));
                var user = userClient.Registration("hmaster.wt@gmail.com", "1", "1");

                if (user != null)
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("BUG");
                }
                user = null;
                user = userClient.SignIn("1", "1");

                if (user != null)
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("BUG");
                }
                //MessageClient message = new MessageClient(new InstanceContext(new CallBackHandler()));
                //message.SendMessage("asd", null, null, null);
                //Console.WriteLine("Done");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
