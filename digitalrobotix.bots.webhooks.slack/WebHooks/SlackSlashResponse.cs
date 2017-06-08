using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace digitalrobotix.bots.webhooks.slack
{
    /// <summary>
    ///  An IWebHookHandler can post a response to a Slack Slash request by updating the
    ///  System.Net.Http.HttpResponseMessage on the WebHookHandlerContext with a response
    ///  containing a SlackSlashResponse
    /// </summary>
    public class SlackSlashResponse
    {
        private readonly Collection<SlackAttachment> _attachments = new Collection<SlackAttachment>();

        private string _text;

        /// <summary>
        /// Initializes a new instance of the SlackSlashResponse class 
        /// </summary>
        public SlackSlashResponse(string text)
            : this(text, new SlackAttachment[0])
        {
        }

        /// <summary>
        /// Initializes a new instance of the SlackSlashResponse class .
        /// </summary>
        public SlackSlashResponse(string text, params SlackAttachment[] attachments)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (attachments == null)
            {
                throw new ArgumentNullException(nameof(attachments));
            }

            _text = text;
            foreach (SlackAttachment att in attachments)
            {
                _attachments.Add(att);
            }
        }

        /// <summary>
        /// Default constructor for serialization purposes
        /// </summary>
        internal SlackSlashResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Slack Slash Response text. 
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

        /// <summary>
        /// Gets or sets the Slack Slash Response type.
        /// </summary>
        [JsonProperty("response_type")]
        public string ResponseType { get; set; }

        /// <summary>
        /// Gets a set of SlackAttachment instances that will comprise the Slack Slash response.
        /// </summary>
        [JsonProperty("attachments")]
        public Collection<SlackAttachment> Attachments
        {
            get
            {
                return _attachments;
            }
        }
    }
}
