using System;
using Telegram.Bot;

namespace digitalrobotix.bots.webhooks.telegram
{
    /// <summary>
    /// Telegram bot
    /// </summary>
    public class Bot
    {
        private TelegramBotClient _api = null; // holds the telegram api
        private string _name = string.Empty;
        public Bot(string name, string token, string webhookUrl)
        {
            _name = name;
            try
            {
                System.Diagnostics.Trace.TraceInformation("Creates the Telegram bot client");
                _api = new TelegramBotClient(token);
                System.Diagnostics.Trace.TraceInformation("Set telegram webhook {0}/{1}", webhookUrl, token);
                _api.SetWebhookAsync(string.Format(webhookUrl, token)).Wait();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Error is occured: {0}", ex.Message);
            }
        }

        public TelegramBotClient Api
        {
            get
            {
                return _api;
            }
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
