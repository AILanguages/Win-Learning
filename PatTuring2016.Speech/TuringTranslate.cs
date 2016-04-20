//-----------------------------------------------------------------------
// <copyright file="TuringTranslate.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using PatTuring2016.Common.ScreenModels;
using PatTuring2016.Speech.Forms;
using PatTuring2016.Speech.Properties;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PatTuring2016.Speech
{
    public class TuringTranslate
    {
        private readonly TranslateSettings _translateSettings;
        private string _url;

        public TuringTranslate(TranslateSettings translateSettings)
        {
            _translateSettings = translateSettings;
            _url = (string)Settings.Default["DataServer"]; // the validated address of the service
        }

        internal void Setup(ContextForm contextForm)
        {
            _translateSettings.Setup(contextForm);
        }

        internal async Task<string> Translate(string sourcetext, string target)
        {
            var matchSettings = _translateSettings.GetSettings(target); // get the settings with the selected target
            var match = new Match { TextIn = sourcetext + ".", UserKey = string.Empty, MatchSettings = matchSettings };

            var stringReturn = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://" + _url + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                HttpResponseMessage response = await client.PostAsJsonAsync("api/v1/translate/", match);
                var matchupdate = await response.Content.ReadAsAsync<Match>();

                if (response.IsSuccessStatusCode)
                {
                    return matchupdate.Response;
                }
            }

            return stringReturn;
        }
    }
}

