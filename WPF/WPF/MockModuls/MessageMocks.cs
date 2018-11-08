using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.MockModuls
{
    public class MessageMocks : IMockData<Message>
    {
        public IEnumerable<Message> GetMock()
        {
            List<Message> message = new List<Message>();
            message.Add(new Message(){Body="Hello" ,Sender=new User() { Name="Loool"},DateTimeSended=DateTime.Now });
            return message;
        }
    }
}
