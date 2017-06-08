﻿using System;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;

namespace digitalrobotix.bots.webhooks.slack
{
    /// <summary>
    /// Provides an WebHookReceiver implementation which supports WebHooks generated by Telegram. 
    /// </summary>
    public class SlackWebHookReceiver : WebHookReceiver
    {
        private const string RecName = "Slack";
        private const string CodeQueryParameter = "code";
        internal const int SecretMinLength = 16;
        internal const int SecretMaxLength = 128;
        internal const string TokenParameter = "token";
        internal const string TriggerParameter = "trigger_word";
        internal const string CommandParameter = "command";
        internal const string TextParameter = "text";
        internal const string SubtextParameter = "subtext";

        /// <summary>
        /// Gets the receiver name for this receiver.
        /// </summary>
        public static string ReceiverName
        {
            get { return RecName; }
        }

        /// <inheritdoc />
        public override string Name
        {
            get { return RecName; }
        }

        /// <inheritdoc />
        public override async Task<HttpResponseMessage> ReceiveAsync(string id, HttpRequestContext context, HttpRequestMessage request)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Method == HttpMethod.Post)
            {
                EnsureSecureConnection(request);

                // Read the request entity body
                NameValueCollection data = await ReadAsFormDataAsync(request);

                // Get the action by looking for either trigger_word or command parameter
                string action = data[TriggerParameter];
                if (!string.IsNullOrEmpty(action))
                {
                    // Get the subtext by removing the trigger word
                    string text = data[TextParameter];
                    data[SubtextParameter] = GetSubtext(action, text);
                }
                else
                {
                    action = data[CommandParameter];
                }

                if (string.IsNullOrEmpty(action))
                {
                    string msg = string.Format(CultureInfo.CurrentCulture, Properties.SlackReceiverResources.Receiver_BadBody, CommandParameter, TriggerParameter);
                    context.Configuration.DependencyResolver.GetLogger().Error(msg);
                    HttpResponseMessage badType = request.CreateErrorResponse(HttpStatusCode.BadRequest, msg);
                    return badType;
                }

                // Call registered handlers
                return await ExecuteWebHookAsync(id, context, request, new string[] { action }, data);
            }
            else
            {
                return CreateBadMethodResponse(request);
            }
        }

        /// <summary>
        /// The 'text' parameter provided by Slack contains both the trigger and the rest of the phrase. This 
        /// isolates just the rest of the phrase making it easier to get in handlers.
        /// </summary>
        internal static string GetSubtext(string trigger, string text)
        {
            return text != null && text.StartsWith(trigger, StringComparison.OrdinalIgnoreCase) ? text.Substring(trigger.Length).Trim() : text != null ? text : string.Empty;
        }
    }
}