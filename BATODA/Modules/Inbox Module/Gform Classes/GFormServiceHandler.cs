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
                GoogleClientSecrets.FromFile(
                    @"..\..\Modules\Inbox Module\GFormAuth\gforms-credentials.json"
                ).Secrets,
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

        public List<GFormResponseModel> GetResponses(string spreadsheetId, string range)
        {
            AuthenticateAndCreateService();

            var request = _service.Spreadsheets.Values.Get(spreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            var result = new List<GFormResponseModel>();

            if (values == null || values.Count <= 1)
                return result;

            for (int i = 1; i < values.Count; i++)
            {
                var row = values[i];

                var responseModel = new GFormResponseModel
                {
                    Timestamp = DateTime.TryParse(row.ElementAtOrDefault(0)?.ToString(), out var dt) ? dt : DateTime.Now,
                    Email = row.ElementAtOrDefault(1)?.ToString() ?? "(No Email)",
                    Name = row.ElementAtOrDefault(2)?.ToString() ?? "(No Name)",
                    question_1 = row.ElementAtOrDefault(3)?.ToString() ?? "(No Answer)",
                    question_2 = row.ElementAtOrDefault(4)?.ToString() ?? "(No Answer)",
                    question_3 = row.ElementAtOrDefault(5)?.ToString() ?? "(No Answer)",
                    question_4 = row.ElementAtOrDefault(6)?.ToString() ?? "(No Answer)"
                };

                result.Add(responseModel);
            }

            return result;
        }



    }

}
