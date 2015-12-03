//-----------------------------------------------------------------------
// <copyright file="SpeechController.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TSTuring2015.Speech
{
    using Common;
    using Forms;
    using LanguageCheckers;
    using SpeechRec;
    using System.Collections.Generic;
    using VoiceSyllabus;

    public class SpeechController
    {
        private readonly SetVoiceMonitoring _setVoiceMonitoring;
        private readonly SyllabusTracker _syllabusTracker;
        private ContextForm _contextForm;
        private SyllabusForm _syllabusForm;
        private readonly SpeakText _speakText;
        private readonly TranslateAndSpeak _translateAndSpeak;

        private Speaker _speaker;
        private AbstractLanguage _abstractLanguage;

        public SpeechController(SetVoiceMonitoring setVoiceMonitoring, ContextForm contextForm,
            SyllabusForm syllabusForm, SyllabusTracker syllabusTracker, SpeakText speakText, DefaultLanguage defaultLanguage,
            TranslateAndSpeak translateAndSpeak)
        {
            _setVoiceMonitoring = setVoiceMonitoring;
            _contextForm = contextForm;
            _syllabusForm = syllabusForm;
            _syllabusTracker = syllabusTracker;

            _speakText = speakText;
            _abstractLanguage = defaultLanguage;

            _translateAndSpeak = translateAndSpeak;
        }

        internal void ClearTextBoxes()
        {
            _speaker.textBox1.Text = string.Empty;
            _speaker.textBox2.Text = string.Empty;
        }

        internal void Setup(Speaker speaker)
        {
            _speaker = speaker;

            _contextForm.Visible = false;
            _contextForm.Setup();
            _contextForm.Show();

            _syllabusForm.Visible = false;
            _syllabusForm.Setup(this, _syllabusTracker);
            _syllabusForm.Show();

            _abstractLanguage.ContextForm = _contextForm;

            _translateAndSpeak.Setup(_speakText, speaker, _contextForm);
        }

        // speak the last sylabus selected
        internal void SayLast()
        {
            SpeakSyllabus(_syllabusTracker.CurrentSyllabus);
        }

        internal void SetQuiet()
        {
            _speakText.ShutUp();
        }

        // speak all syllabi entered
        internal void OnSyllabusSelected()
        {
            foreach (var baseSyllabus in _syllabusTracker.Syllabi)
            {
                SpeakSyllabus(baseSyllabus);
            }
        }

        private void SpeakSyllabus(BaseSyllabus syllabus)
        {
            if (syllabus == null) return;

            foreach (var phrase in syllabus.Commands)
            {
                HandleSpeech(phrase);
            }
        }

        internal void CloseWindows()
        {
            _contextForm.Close();
            _syllabusForm.Close();
        }

        internal void AddSyllabus(BaseSyllabus currentSyllabus)
        {
            _syllabusTracker.AddSyllabus(currentSyllabus);
        }

        internal void OnDisplayRequested()
        {
            var syllabus = _syllabusTracker.CurrentSyllabus;
            if (syllabus == null) return;

            OnDisplaySelected(syllabus);
        }

        internal void LoadSyllabus()
        {
            _setVoiceMonitoring.CreateEngine(this, _speaker.cbxSource.Text); // setup current langauge recognition
            _setVoiceMonitoring.LoadCurrentSyllabus(_syllabusTracker, _abstractLanguage); // load full syllabus/commands
        }

        internal void SetVoiceMonitoring()
        {
            LoadSyllabus();
            _setVoiceMonitoring.Recognize();
        }

        internal void StopRecognize()
        {
            _setVoiceMonitoring.StopRecognize();
        }

        internal void RandomNoiseDetected(string text, string confidence)
        {
            _speaker.lblError.Text = "Random noise detected.";
            _speaker.lblPercent.Text = confidence;
            _speaker.lblErrorSound.Text = string.Empty;
            _speaker.lblErrorSound.Text = text;
        }

        internal void UnderThresholdNoiseDetected(string text)
        {
            _speaker.lblError.Text = "Under threshold: what's that?";
            _speaker.lblPercent.Text = text;
        }

        internal void Init()
        {
            _speaker.lblError.Text = string.Empty;
            _speaker.lblPercent.Text = string.Empty;
            _speaker.lblErrorSound.Text = string.Empty;
        }

        internal IEnumerable<string> CkLstTargetsChanged()
        {
            if (_speaker.ckLstTargets.CheckedItems.Count == 1)
            {
                foreach (var checkedItem in _speaker.ckLstTargets.CheckedItems)
                {
                    yield return checkedItem.ToString();
                }
            }
        }

        internal void MoreContext()
        {
            if (_contextForm.IsDisposed)
            {
                _contextForm = new ContextForm();
                Setup((_speaker));
            }
            ShowContextForm();

            if (_syllabusForm.IsDisposed)
            {
                _syllabusForm = new SyllabusForm();
                Setup(_speaker);
            }
            ShowSylabusForm();
        }

        private void ShowSylabusForm()
        {
            _syllabusForm.Visible = true;
            _syllabusForm.TopMost = true;
        }

        private void ShowContextForm()
        {
            _contextForm.Visible = true;
            _contextForm.TopMost = true;
        }


        // return true if recognized speech was a command
        private bool SpeechIsCommand(string text)
        {
            // if langauge change, set it
            if (_abstractLanguage.SetTargetLanguage(text, this)) return true;

            return _abstractLanguage.MakeCommandChange(text, _speaker, this);
        }

        private void OnDisplaySelected(BaseSyllabus syllabus)
        {
            _speakText.AppendThis(syllabus.Name, _speaker.textBox1); // source side
            _speakText.AppendThis(syllabus.Name, _speaker.textBox2); // target side

            // now display the syllabus on the screen
            foreach (var syllabi in syllabus.Commands)
            {
                _speakText.AppendThis(syllabi, _speaker.textBox1);
            }
        }

        internal void ChangeTargetTo(AllLanguageList newTarget)
        {
            _speaker.SetSingleLanguage(newTarget);
        }

        internal void HandleSpeech(string text)
        {
            if (SpeechIsCommand(text))
            {
                _abstractLanguage = AbstractLanguageFactory.GetFactory(text, _abstractLanguage);
                return;
            }

            _translateAndSpeak.HandleText(text);
        }
    }
}