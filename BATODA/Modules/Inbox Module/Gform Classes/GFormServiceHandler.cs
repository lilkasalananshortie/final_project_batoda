using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BATODA.Modules.Inbox_Module.Gform_Classes
{
    internal class GFormServiceHandler
    {
        private SheetsService _service;

        public SheetsService AuthenticateAndCreateService()
        {
            if (_service != null) return _service;

            string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromFile(@"GFormAuth/credentials.json").Secrets,
                Scopes,
                "user",
                CancellationToken.None
            ).Result;

            _service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Batoda GForm Viewer"
            });

            return _service;
        }
    }

}
