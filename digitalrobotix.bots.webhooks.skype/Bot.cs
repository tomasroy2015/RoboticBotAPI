using System;
using Newtonsoft.Json.Linq;


namespace digitalrobotix.bots.webhooks.skype
{
    /// <summary>
    /// Telegram bot
    /// </summary>
    public class Bot
    {
        private string _name = string.Empty;
        public Bot(string name, string token, string webhookUrl)
        {
            _name = name;
        }
                
        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}
