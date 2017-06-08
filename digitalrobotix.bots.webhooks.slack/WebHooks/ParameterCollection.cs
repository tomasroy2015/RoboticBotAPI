using System.Collections.Specialized;
using System.Text;

namespace digitalrobotix.bots.webhooks.slack
{
    /// <summary>
    /// This version of NameValueCollection creates the output supported by SlackCommand.ParseActionWithParameters
    /// </summary>
    internal class ParameterCollection : NameValueCollection
    {
        /// <inheritdoc />
        public override string ToString()
        {
            bool first = true;
            StringBuilder output = new StringBuilder();
            foreach (string key in this.AllKeys)
            {
                output.AppendFormat("{0}{1}={2}", first ? string.Empty : "; ", key, this[key]);
                first = false;
            }
            return output.ToString();
        }
    }
}
