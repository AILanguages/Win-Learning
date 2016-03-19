//-----------------------------------------------------------------------
// <copyright file="TranslateAndSpeak.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using PatTuring2016.Speech.Forms;
using PatTuring2016.Speech.SpeechRec;

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

        internal void HandleText(string text)
        {
            // OK, not a command, look for syllabus
            if (!(_speaker.ckLstTargets.CheckedItems.Count > 1))
            {
                LogTextConvertAndSpeak(text, _speaker.GetSingleLanguage());
            }
            else
            {
                LogMultiLanguageText(text);
            }
        }

        private void LogMultiLanguageText(string text)
        {
            RepeatInput(text);

            foreach (var language in _speaker.ckLstTargets.CheckedItems)
            {
                SayLanguageAndTarget(text, language.ToString());
            }
        }

        private void RepeatInput(string text)
        {
            _speakText.AppendThis(text, _speaker.textBox1);
            if (_speaker.rbnTargetOnly.Checked) return;

            _speakText.SpeakWithVoice(text, _speaker.cbxSource.Text);
        }

        private void SayLanguageAndTarget(string text, string language)
        {
            // say language in source language
            WriteAndSpeakSource(language, _speaker.cbxSource.Text);

            // target language speaker
            WriteAndSpeakTarget(text, language);
        }
        
        private void LogTextConvertAndSpeak(string text, string target)
        {
            _speakText.AppendThis(text, _speaker.textBox1);
            if (_speaker.rbnTargetOnly.Checked) return;

            _speakText.SpeakWithVoice(text, _speaker.cbxSource.Text);

            WriteAndSpeakTranslation(text, target);
        }

        private void WriteAndSpeakTranslation(string text, string target)
        {
            if (target.EndsWith("English"))
            {
                target = "English";
            }

            var sourcetext = _speaker.rdAccentOnly.Checked ? text :
                _turingTranslate.Translate(text, _speaker, target);

            _speakText.AppendThis(sourcetext, _speaker.textBox2);
            _speakText.SpeakWithVoice(sourcetext, target);
        }

        private void WriteAndSpeakSource(string text, string target)
        {
            _speakText.AppendThis(text, _speaker.textBox2);
            _speakText.SpeakWithVoice(text, target);
        }

        private void WriteAndSpeakTarget(string text, string target)
        {
            var sourcetext = _turingTranslate.Translate(text, _speaker, target);

            _speakText.AppendThis(sourcetext, _speaker.textBox2);
            _speakText.SpeakWithVoice(sourcetext, target);
        }
    }
}