using System;
using System.Collections.Generic;
using System.Configuration;

namespace digitalrobotix.bots.webhooks.email
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
            public static readonly string WebHook = "EmailWebHook";
            public static readonly string Bots = "EmailBots";
        }

        private static string bots_info_delimeter = "|";
        private static string bot_info_delimeter = ";";

        private Dictionary<string, Bot> _bots = new Dictionary<string, Bot>();

        private BotFactory()
        {
        }

        public void InitializeBots()
        {
            string[] bots = ConfigurationManager.AppSettings[AppSettingsKey.Bots].Split(bots_info_delimeter.ToCharArray());
            if ((bots != null) && (bots.Length > 0))
            {
                foreach (string bot in bots)
                {
                    string[] botInfo = bot.Split(bot_info_delimeter.ToCharArray());
                    if ((botInfo != null) && (botInfo.Length > 0))
                    {
                        if (!_bots.ContainsKey(botInfo[1]))
                            _bots.Add(botInfo[1], new Bot(botInfo[0], botInfo[1], ConfigurationManager.AppSettings[AppSettingsKey.WebHook]));
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
