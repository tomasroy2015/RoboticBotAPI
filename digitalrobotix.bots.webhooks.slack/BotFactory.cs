using System;
using System.Collections.Generic;
using System.Configuration;

namespace digitalrobotix.bots.webhooks.slack
{
    public sealed class BotFactory
    {
        class Nested
        {
            static Nested()
            {
            }

            internal static readonly BotFactory _helper = new BotFactory();
        }

        public static BotFactory GetInstance()
        {
            return Nested._helper;
        }

        private class AppSettingsKey
        {
            public static readonly string WebHook = "SlackWebHook";
            public static readonly string Bots = "SlackBots";
        }
        // xoxb-64055764166-inIsWxVLY14LWDHXJB8vg7TR
        // @yusesofttestbot
        // team token - xd76CEv0rZJsaVvqNpfRUykW
        // incoming url - https://hooks.slack.com/services/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

        private static string bots_info_delimeter = "|";
        private static string bot_info_delimeter = ";";

        private Dictionary<string, Bot> _bots = new Dictionary<string, Bot>();

        private BotFactory()
        {
        }

        public void InitializeBots()
        {
            System.Diagnostics.Trace.TraceInformation("Inititalizing the Slack bots");

            string[] bots = ConfigurationManager.AppSettings[AppSettingsKey.Bots].Split(bots_info_delimeter.ToCharArray());
            if ((bots != null) && (bots.Length > 0))
            {
                System.Diagnostics.Trace.TraceInformation("Found {0} slack bots", bots.Length);
                foreach (string bot in bots)
                {
                    string[] botInfo = bot.Split(bot_info_delimeter.ToCharArray());
                    if ((botInfo != null) && (botInfo.Length > 0))
                    {
                        System.Diagnostics.Trace.TraceInformation("Initializing the bot {0}", botInfo[0]);

                        if (!_bots.ContainsKey(botInfo[1]))
                            _bots.Add(botInfo[1], new Bot(botInfo[0], botInfo[1], ConfigurationManager.AppSettings[AppSettingsKey.WebHook]));
                        else
                            System.Diagnostics.Trace.TraceInformation("The bot with name {0} and token {1} already exist", botInfo[0], botInfo[1]);
                    }
                }
            }
        }

        public Bot GetBot(string token)
        {
            if (_bots.ContainsKey(token))
                return _bots[token];

            return null;
        }
    }
}
