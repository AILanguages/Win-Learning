//-----------------------------------------------------------------------
// <copyright file="TranslateSettings.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using PatTuring2016.Common.ScreenModels;
using PatTuring2016.Speech.Forms;
using PatTuring2016.Speech.Validation;

namespace PatTuring2016.Speech
{
    public class TranslateSettings
    {
        private ContextForm _contextForm;
        private readonly FindSettings _findSettings;

        public TranslateSettings()
        {
            _findSettings = new FindSettings();
        }

        internal void Setup(ContextForm contextForm)
        {
            _contextForm = contextForm;
        }

        internal MatchSettings GetSettings(string target)
        {
            _findSettings.Update(target, _contextForm);
            return _findSettings.MatchSettings;
        }
    }
}