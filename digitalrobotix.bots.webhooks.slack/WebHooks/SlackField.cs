using System;
using Newtonsoft.Json;

namespace digitalrobotix.bots.webhooks.slack
{
    /// <summary>
    /// The SlackField class is used for expression table fields as part of a SlackAttachment
    /// </summary>
    public class SlackField
    {
        private string _title;
        private string _value;

        /// <summary>
        /// Initializes a new instance of the SlackField with the given title and value. 
        /// </summary>
        public SlackField(string title, string value)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _title = title;
            _value = value;
        }

        /// <summary>
        /// Default constructor for serialization purposes
        /// </summary>
        internal SlackField()
        {
        }

        /// <summary>
        /// Gets or sets the field title shown as a bold heading above the value text. It cannot contain markup and will be escaped
        /// by the receiver.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _title = value;
            }
        }

        /// <summary>
        /// Gets or sets the field value.
        /// </summary>
        [JsonProperty("value")]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _value = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the field is short enough to be displayed side-by-side with other fields.
        /// </summary>
        [JsonProperty("short")]
        public bool Short { get; set; }
    }
}
