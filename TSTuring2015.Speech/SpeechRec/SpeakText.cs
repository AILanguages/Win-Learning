//-----------------------------------------------------------------------
// <copyright file="SpeakText.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TSTuring2015.Speech.SpeechRec
{
    using System;
    using System.Speech.Synthesis;
    using System.Windows.Forms;

    public class SpeakText
    {
        private readonly SpeechSynthesizer _speechSynthesizer;
        private readonly PromptBuilder _promptBuilder;

        public SpeakText(SpeechSynthesizer speechSynthesizer)
        {
            _speechSynthesizer = speechSynthesizer;
            _promptBuilder = new PromptBuilder();
        }

        internal void AppendThis(string text, TextBox textBox)
        {
            textBox.AppendText(text);
            textBox.AppendText(Environment.NewLine);
        }

        internal void SpeakWithVoice(string text, string target)
        {
            _promptBuilder.ClearContent();
            _promptBuilder.StartVoice(LanguageSelector.GetVoice(target)); // source accent
            _promptBuilder.AppendText(CorrectText(text));

            //  _promptBuilder.AppendSsmlMarkup(". <prosody rate=\"slow\"> That is a <emphasis> big </emphasis> car!</prosody>");
            //string high = "<prosody pitch=\"x-high\"> This is extra high pitch. </prosody >";
            //string loud = "<prosody volume=\"x-loud\"> This is extra loud volume. </prosody>";
            //string slow = "<prosody rate=\"slow\"> This is the slow speaking rate. </prosody>";
            //_promptBuilder.AppendSsmlMarkup(high);
            //_promptBuilder.AppendSsmlMarkup(loud);
            //_promptBuilder.AppendSsmlMarkup(slow);

            _promptBuilder.EndVoice();
            Speak();
        }

        private string CorrectText(string text)
        {
            // correct text if needed for sound - temporary while using Microsoft Speech synthesizer
            if (text == "she read the book.")
                return "she red the book.";

            return text;
        }

        private void Speak()
        {
            _speechSynthesizer.SpeakAsync(_promptBuilder);
        }

        internal void ShutUp()
        {
            _speechSynthesizer.SpeakAsyncCancelAll();
        }
    }
}