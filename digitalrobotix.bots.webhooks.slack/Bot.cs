using System;
using System.Threading.Tasks;
using SlackConnector.Models;

namespace digitalrobotix.bots.webhooks.slack
{
    /// <summary>
    /// Telegram bot
    /// </summary>
    public class Bot
    {
        private string _name = string.Empty;
        private SlackConnector.SlackConnector _connector = null;
        private SlackConnector.ISlackConnection _connection = null;

        public Bot(string name, string token, string webhookUrl)
        {
            _name = name;

            try
            {
                System.Diagnostics.Trace.TraceInformation("Creates the Slack bot connector");
                _connector = new SlackConnector.SlackConnector();

                System.Diagnostics.Trace.TraceInformation("Connect to the slack bot. Token {0}", token);
                _connection = _connector.Connect(token).Result;
                _connection.OnDisconnect += Connection_OnDisconnect;
                _connection.OnMessageReceived += Connection_OnMessageReceived;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Error is occured: {0}", ex.Message);
            }
        }

        private Task Connection_OnMessageReceived(SlackMessage message)
        {
            System.Diagnostics.Trace.TraceInformation("Slack bot's message received: {0}", message.Text);
            BotMessage botMessage = new BotMessage
            {
                Text = string.Format("{0}: Iman Says - {1}", _name, message.Text),
                ChatHub = message.ChatHub
            };

            return _connection.Say(botMessage);
        }

        private void Connection_OnDisconnect()
        {
            System.Diagnostics.Trace.TraceInformation("Bot {0} disconnected", _name);
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
