using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace BATODA.Modules.Inbox_Module.Inbox_Classes
{
    internal class GmailServiceHandler
    {
        private static readonly string[] Scopes = { GmailService.Scope.GmailReadonly };
        private const string ApplicationName = "Batoda Gmail OAuth";
        private GmailService _service;

        // AUTHENTICATE AND CREATE GMAIL SERVICE
        public void Authenticate()
        {
            UserCredential credential;

            using (var stream = new FileStream(@"..\..\Modules\Inbox Module\GmailAuth\credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            _service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        // GET MESSAGES WITH SUBJECT + SNIPPET + DATE
        public List<(string Id, string Subject, string Snippet, DateTime Date)> GetMessages(int maxResults = 10)
        {
            if (_service == null)
                Authenticate();

            var listRequest = _service.Users.Messages.List("me");
            listRequest.MaxResults = maxResults * 2;
            var messages = listRequest.Execute().Messages;

            var result = new List<(string Id, string Subject, string Snippet, DateTime Date)>();

            foreach (var msg in messages)
            {
                var message = _service.Users.Messages.Get("me", msg.Id).Execute();
                string subject = message.Payload.Headers.FirstOrDefault(h => h.Name == "Subject")?.Value ?? "(No Subject)";
                string snippet = message.Snippet ?? "";
                long timestamp = message.InternalDate ?? 0;
                DateTime date = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;

                result.Add((msg.Id, subject, snippet, date));
            }

            return result.OrderByDescending(m => m.Date).Take(maxResults).ToList();
        }



        public string FormatMessageTime(DateTime messageTime)
        {
            var now = DateTime.Now;
            var diff = now - messageTime;

            if (diff.TotalDays < 1)
            {
                if (diff.TotalHours >= 1)
                    return $"{(int)diff.TotalHours} hours ago";
                else if (diff.TotalMinutes >= 1)
                    return $"{(int)diff.TotalMinutes} minutes ago";
                else
                    return "Just now";
            }
            else if (diff.TotalDays < 2)
            {
                return "Yesterday";
            }
            else
            {
                return messageTime.ToString("MMMM dd, yyyy");
            }
        }

        public string GetPreview(string messageId, int length = 50)
        {
            var fullMsg = GetFullMessage(messageId);
            string body = fullMsg.Body.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
            return body.Length > length ? body.Substring(0, length) + "..." : body;
        }




        public (string From, DateTime Date, string Body) GetFullMessage(string messageId)
        {
            if (_service == null)
                Authenticate();

            var message = _service.Users.Messages.Get("me", messageId).Execute();

            string from = message.Payload.Headers.FirstOrDefault(h => h.Name == "From")?.Value ?? "(Unknown Sender)";
            long timestamp = message.InternalDate ?? 0;
            DateTime date = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;

            string body = "";
            if (message.Payload.Parts != null && message.Payload.Parts.Count > 0)
            {
                foreach (var part in message.Payload.Parts)
                {
                    if (part.MimeType == "text/plain")
                    {
                        body = part.Body.Data != null ? Base64UrlDecode(part.Body.Data) : "";
                        break;
                    }
                }
            }
            else
            {
                body = message.Payload.Body.Data != null ? Base64UrlDecode(message.Payload.Body.Data) : "";
            }

            return (from, date, body);
        }

        private string Base64UrlDecode(string input)
        {
            string s = input.Replace('-', '+').Replace('_', '/');
            switch (s.Length % 4)
            {
                case 2: s += "=="; break;
                case 3: s += "="; break;
            }
            var bytes = Convert.FromBase64String(s);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }


    }

}
