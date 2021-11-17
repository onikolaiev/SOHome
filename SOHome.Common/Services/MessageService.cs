using System;
using System.Collections.Generic;
using System.Text;

namespace SOHome.Common.Services
{
    public interface IMessageService
    {
        string GetMessage();
    }
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from Message Service & Dependency Injection";
        }
    }
}
