using System.Collections.Generic;
using System.Linq;

namespace towerdef.Main
{
    public class ServiceBus
    {
        private List<string> _messages;

        public ServiceBus()
        {
            _messages = new List<string>();
        }

        public void AddMessage(string msg)
        {
            _messages.Add(msg);
        }
        
        public string GetLast()
        {
            var msg = _messages.FirstOrDefault();
            if (msg == null)
                return null;

            _messages.Remove(msg);

            return msg;
        }
    }
}
