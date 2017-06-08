using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using digitalrobotix.bots.webhooks.telegram;

namespace digitalrobotix.bots.webapi
{
    public class TelegramWebHookHandler : WebHookHandler
    {
        public TelegramWebHookHandler()
        {
            this.Receiver = TelegramWebHookReceiver.ReceiverName;
        }

        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            JObject entry = context.GetDataOrDefault<JObject>();
            
            return Task.FromResult(true);
        }
    }
}