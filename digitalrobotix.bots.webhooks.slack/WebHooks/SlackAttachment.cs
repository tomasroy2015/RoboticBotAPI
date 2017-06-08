using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace digitalrobotix.bots.webhooks.slack
{
    /// <summary>
    ///  The SlackAttachment is used to describe the contents of an SlackSlashResponse
    /// </summary>
    public class SlackAttachment
    {
        private readonly Collection<SlackField> _fields = new Collection<SlackField>();

        private string _text;
        private string _fallback;

        /// <summary>
        /// Initializes a new instance of the SlackAttachment class 
        /// </summary>
        public SlackAttachment(string text, string fallback)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (fallback == null)
            {
                throw new ArgumentNullException(nameof(fallback));
            }
            _text = text;
            _fallback = fallback;
        }

        /// <summary>
        /// Default constructor for serialization purposes
        /// </summary>
        internal SlackAttachment()
        {
        }

        /// <summary>
        /// Gets or sets a required plain-text summary of the attachment. This text will be used in clients 
        /// that don't show formatted text (e.g. IRC, mobile notifications) and should not contain 
        /// any markup.
        /// </summary>
        [JsonProperty("fallback")]
        public string Fallback
        {
            get
            {
                return _fallback;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _fallback = value;
            }
        }

        /// <summary>
        /// Gets or sets an optional value that can either be one of good, warning, danger, 
        /// or any hex color code
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets an optional text that appears above the message attachment block.
        /// </summary>
        [JsonProperty("pretext")]
        public string Pretext { get; set; }

        /// <summary>
        /// Gets or sets an optional small text used to display the author's name.
        /// </summary>
        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets a URI that will show up as a hyper link for the AuthorName text.
        /// </summary>
        [JsonProperty("author_link")]
        public Uri AuthorLink { get; set; }

        /// <summary>
        /// Gets or sets a URI that display a small 16x16 pixel image to the left of the AuthorName text.
        /// </summary>
        [JsonProperty("author_icon")]
        public Uri AuthorIcon { get; set; }

        /// <summary>
        /// Gets or sets an optional title which is displayed as larger, bold text near the top of a message attachment. 
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a hyper link for the Title text. This will only be applied if  
        /// <see cref="Title"/> is present.
        /// </summary>
        [JsonProperty("title_link")]
        public Uri TitleLink { get; set; }

        /// <summary>
        /// Gets or sets the main text in a message attachment. The text may contain Markdown-style formatting as described in https://api.slack.com/docs/formatting.
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
        /// Gets or a URI to an image that will be displayed inside a message attachment. Currently supported formats include GIF, JPEG, PNG, and BMP.
        /// </summary>
        [JsonProperty("image_url")]
        public Uri ImageLink { get; set; }

        /// <summary>
        /// Gets or a URI to an image that will be displayed as a thumbnail on the right side of a message attachment. Currently supported formats 
        /// include GIF, JPEG, PNG, and BMP.
        /// </summary>
        [JsonProperty("thumb_url")]
        public Uri ThumbLink { get; set; }

        /// <summary>
        /// Gets a set of SlackField instances that will be displayed in a table inside the message attachment
        /// </summary>
        [JsonProperty("fields")]
        public Collection<SlackField> Fields
        {
            get
            {
                return _fields;
            }
        }
    }
}
