using System;
using Newtonsoft.Json;

namespace digitalrobotix.bots.webhooks.slack
{
    /// <summary>
    ///  An IWebHookHandler can post back a response to a Slack channel by updating the
    ///  System.Net.Http.HttpResponseMessage on the WebHookHandlerContext with a response
    ///  containing a SlackResponse
    /// </summary>
    public class SlackResponse
    {
        private string _text;

        /// <summary>
        /// Initializes a new instance of the SlackResponse with a given text to post
        /// to the Slack channel from which the WebHook were received.
        /// </summary>
        public SlackResponse(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            _text = text;
        }

        /// <summary>
        /// Gets or sets the text to send to Slack in response to an incoming WebHook request. 
        /// </summary>
        [JsonProperty("text")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _text = value;
            }
        }
    }
}
