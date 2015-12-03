﻿//-----------------------------------------------------------------------
// <copyright file="TuringTranslate.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TSTuring2015.Speech
{
    using Forms;
    using Properties;
    using ScreenModels;
    using ScreenModels.FullScreenModels;
    using WindowsProxy;
    using WindowsProxy.Facades;

    public class TuringTranslate
    {
        private readonly TranslateSettings _translateSettings;
        private readonly SettingsServiceFacade _settingsServiceFacade;
        private readonly TranslateServiceFacade _translateServiceFacade;

        public TuringTranslate(TranslateSettings translateSettings)
        {
            _translateSettings = translateSettings;
            var service = (string)Settings.Default["DataServer"]; // the validated address of the service
            var facades = new GetFacades(service);

            _translateServiceFacade = facades.GetTranslateServiceFacade();
            _settingsServiceFacade = facades.GetSettingsServiceFacade();
        }

        internal void Setup(ContextForm contextForm)
        {
            _translateSettings.Setup(contextForm);
        }

        internal string Translate(string sourcetext, Speaker speaker, string target)
        {
            var tvm = GetTranslation(sourcetext + ".", target);
            if (tvm.Translations.Count == 0) return "what?";

            return tvm.Translations[0].Target;
        }

        private TranslateViewModel GetTranslation(string sourceText, string target)
        {
            var tvm = MakeTranslateViewModel(sourceText, target);
            _settingsServiceFacade.UpdateSettings(tvm.MatchSettings, tvm.SampleSettings);

            var getmatch = _translateServiceFacade.GetMatchFor(tvm.Match);

            if (getmatch.MatchesSuccessfullyFound)
            {
                var screen = _translateServiceFacade.GetCurrentScreen();
                var clause = screen.ScreenModel as FullClauseScreenModel;

                // let's add to the existing list
                var tp = new TranslatePair
                {
                    Source = tvm.LastSearch,
                    Target = clause.Translation
                };

                tvm.Translations.Add(tp);
            }

            return tvm;
        }

        private TranslateViewModel MakeTranslateViewModel(string sourceText, string target)
        {
            var settings = _translateSettings.UpdateTranslateSettings(target);

            var match = new Match { TextIn = sourceText };

            return new TranslateViewModel { MatchSettings = settings, Match = match, LastSearch = sourceText };
        }
    }
}
