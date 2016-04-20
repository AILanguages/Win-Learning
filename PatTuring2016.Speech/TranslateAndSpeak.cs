//-----------------------------------------------------------------------
// <copyright file="TranslateAndSpeak.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using PatTuring2016.Speech.Forms;
using PatTuring2016.Speech.SpeechRec;
using System.Threading.Tasks;

namespace PatTuring2016.Speech
{
    public class TranslateAndSpeak
    {
        private readonly TuringTranslate _turingTranslate;
        private SpeakText _speakText;
        private Speaker _speaker;

        public TranslateAndSpeak(TuringTranslate turingTranslate)
        {
            _turingTranslate = turingTranslate;
        }

        internal void Setup(SpeakText speakText, Speaker speaker, ContextForm contextForm)
        {
            _speakText = speakText;
            _speaker = speaker;
            _turingTranslate.Setup(contextForm);
        }

        internal async Task HandleText(string text)
        {
            // OK, not a command, look for syllabus
            if (!(_speaker.ckLstTargets.CheckedItems.Count > 1))
            {
                await LogTextConvertAndSpeak(text, _speaker.GetSingleLanguage());
            }
            else
            {
                LogMultiLanguageText(text);
            }
        }

        private async void LogMultiLanguageText(string text)
        {
            RepeatInput(text);

            foreach (var language in _speaker.ckLstTargets.CheckedItems)
            {
                // say language in source language
                _speakText.AppendThis(language.ToString(), _speaker.textBox2);
                _speakText.SpeakWithVoice(language.ToString(), _speaker.cbxSource.Text);

                // target language speaker
                var sourcetext = await _turingTranslate.Translate(text, language.ToString());

                _speakText.AppendThis(sourcetext, _speaker.textBox2);
                _speakText.SpeakWithVoice(sourcetext, language.ToString());
            }
        }

        private void RepeatInput(string text)
        {
            _speakText.AppendThis(text, _speaker.textBox1);
            if (_speaker.rbnTargetOnly.Checked) return;

            _speakText.SpeakWithVoice(text, _speaker.cbxSource.Text);
        }

        private async Task LogTextConvertAndSpeak(string text, string target)
        {
            _speakText.AppendThis(text, _speaker.textBox1);
            if (_speaker.rbnTargetOnly.Checked) return;

            _speakText.SpeakWithVoice(text, _speaker.cbxSource.Text);

            if (target.EndsWith("English"))
            {
                target = "English";
            }

            var translate = await _turingTranslate.Translate(text, target);

            var sourcetext = _speaker.rdAccentOnly.Checked ? text :
             translate;

            _speakText.AppendThis(sourcetext, _speaker.textBox2);
            _speakText.SpeakWithVoice(sourcetext, target);
        }
    }
}