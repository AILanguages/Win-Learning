//-----------------------------------------------------------------------
// <copyright file="AbstractLanguage.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using PatTuring2016.Common;
using PatTuring2016.Speech.Forms;
using System;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace PatTuring2016.Speech.LanguageCheckers
{
    public abstract class AbstractLanguage
    {
        internal ContextForm ContextForm { get; set; }

        // take verbal command and change system settings
        internal virtual bool SetTargetLanguage(string language, SpeechController speechController)
        {
            switch (language)
            {
                case "mandarin":
                case "german":
                case "italian":
                case "cantonese":
                case "french":
                case "portuguese":
                case "spanish":
                    var lang = (AllLanguageList)Enum.Parse(typeof(AllLanguageList),
                        char.ToUpper(language[0]) + language.Substring(1));
                    speechController.ChangeTargetTo(lang);
                    return true;

                case "japanese":
                    speechController.ChangeTargetTo(AllLanguageList.Japanese);
                    return true;

                case "korean":
                    speechController.ChangeTargetTo(AllLanguageList.Korean);
                    return true;

                case "australian":
                    speechController.ChangeTargetTo(AllLanguageList.OzEnglish);
                    return true;
                case "american":
                    speechController.ChangeTargetTo(AllLanguageList.USEnglish);
                    return true;
                case "english":
                    speechController.ChangeTargetTo(AllLanguageList.UKEnglish);
                    return true;
            }

            return false;
        }

        internal void SetIntimate(SpeechController speechController)
        {
            ContextForm.cbxPolite.Text = "Low";
            ContextForm.cbxFormality.Text = "Neutral";
        }

        internal void SetPolite(SpeechController speechController)
        {
            ContextForm.cbxPolite.Text = "Neutral";
            ContextForm.cbxFormality.Text = "Neutral";
        }

        internal void SetFormal(SpeechController speechController)
        {
            ContextForm.cbxPolite.Text = "Neutral";
            ContextForm.cbxFormality.Text = "High";
        }

        internal void SetLetters(SpeechController speechController)
        {
            ContextForm.cbxDisplay.Text = "Letters";
        }

        internal void SetCharacters(SpeechController speechController)
        {
            ContextForm.cbxDisplay.Text = "Characters";
        }

        internal void SetPhonetics(SpeechController speechController)
        {
            ContextForm.cbxDisplay.Text = "Phonetics";
        }

        internal abstract void Reset(Speaker speaker);

        internal abstract void AddCommands(Choices commandLoad);

        protected void ResetTarget(Speaker speaker)
        {
            speaker.ResetTarget();
        }

        // return true if we should continue
        internal abstract bool SpeechIsCommand(string text, Speaker speaker, SpeechController speechController);

        protected abstract void SetSourceToo(Speaker speaker);

        protected abstract void SetTargetOnly(Speaker speaker);

        internal virtual bool MakeCommandChange(string text, Speaker speaker, SpeechController speechController)
        {
            // deal with commands if present
            switch (text)
            {
                case "target only":
                    speaker.rbnTargetOnly.Checked = true;
                    return true;

                case "confirm source":
                    speaker.rbnTargetOnly.Checked = false;
                    return true;

                case "reset":
                    Reset(speaker);
                    return true;

                case "formal":
                    SetFormal(speechController);
                    return true;

                case "polite":
                    SetPolite(speechController);
                    return true;

                case "intimate":
                    SetIntimate(speechController);
                    return true;

                case "letters":
                    SetLetters(speechController);
                    return true;

                case "characters":
                    SetCharacters(speechController);
                    return true;

                case "phonetics":
                    SetPhonetics(speechController);
                    return true;

                case "close the program":
                    Application.Exit();
                    return true;
            }

            return false;
        }
    }
}