using System.ComponentModel;
using Microsoft.AspNet.WebHooks.Config;
using digitalrobotix.bots.webhooks.email;

namespace System.Web.Http
{
    /// <summary>
    /// Extension methods for <see cref="HttpConfiguration"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class HttpConfigurationExtensions
    {
        /// <summary>
        /// Initializes support for receiving Telegram WebHooks.
        /// </summary>
        /// <param name="config">The current <see cref="HttpConfiguration"/>config.</param>
        public static void InitializeReceiveSkypeWebHooks(this HttpConfiguration config)
        {
            BotFactory.GetInstance().InitializeBots();
            WebHooksConfig.Initialize(config);
        }
    }
}
