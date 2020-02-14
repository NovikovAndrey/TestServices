using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServices.Services
{
    public class MessageService
    {
        IMessageSender sender;
        public MessageService(IMessageSender messageSender)
        {
            sender = messageSender;
        }
        public string Send()
        {
            return sender.Send();
        }
    }
}
