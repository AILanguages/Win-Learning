//-----------------------------------------------------------------------
// <copyright file="SetVoiceMonitoring.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using PatTuring2016.Speech.LanguageCheckers;
using System.Globalization;
using System.Speech.Recognition;

namespace PatTuring2016.Speech.SpeechRec
{

    public class SetVoiceMonitoring
    {
        private SpeechRecognitionEngine _speechRecognitionEngine;
        private CultureInfo _cultureInfo;
        private SpeechController _speechController;
        private const double Threshold = 0.7;

        internal void CreateEngine(SpeechController speechController, string source)
        {
            _speechController = speechController;

            _cultureInfo = LanguageSelector.GetVoice(source); // listen in source language (speech limitation) 
            _speechRecognitionEngine = new SpeechRecognitionEngine(_cultureInfo);
        }

        internal void LoadCurrentSyllabus(SyllabusTracker syllabusTracker, AbstractLanguage abstractLanguage)
        {
            if (_speechRecognitionEngine == null) return; // not currently running recognition

            _speechRecognitionEngine.RequestRecognizerUpdate();
            _speechRecognitionEngine.UnloadAllGrammars();

            // new choices consolidation for commands - one command per syllabus file line
            var commandLoad = new Choices();
            foreach (var baseSyllabus in syllabusTracker.Syllabi)
            {
                foreach (var command in baseSyllabus.Commands)
                {
                    commandLoad.Add(command);
                }
            }

            // add commands - should be per input language, but now English
            VoiceCommands.AddCommands(commandLoad);

            // add commands - per input language
            abstractLanguage.AddCommands(commandLoad);

            var gBuilder = new GrammarBuilder();
            gBuilder.Append(commandLoad);
            var grammar = new Grammar(gBuilder) { Name = "Syllabus" };
            _speechRecognitionEngine.LoadGrammar(grammar);

            var dictgrammar = new DictationGrammar("grammar:dictation#pronunciation") { Name = "Random" };
            _speechRecognitionEngine.LoadGrammar(dictgrammar);
        }

        internal void Recognize()
        {
            _speechRecognitionEngine.SetInputToDefaultAudioDevice();
            _speechRecognitionEngine.SpeechRecognized += OnSpeechRecognized;

            _speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        internal void StopRecognize()
        {
            _speechRecognitionEngine?.RecognizeAsyncStop();
        }

        private void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs speechRecognizedEventArgs)
        {
            _speechController.Init();

            if (speechRecognizedEventArgs.Result?.Grammar == null) return;

            if (speechRecognizedEventArgs.Result.Grammar.Name == "Random")
            {
                _speechController.RandomNoiseDetected(speechRecognizedEventArgs.Result.Text,
                    speechRecognizedEventArgs.Result.Confidence.ToString("P2"));
                return;
            }

            // not random
            if (speechRecognizedEventArgs.Result.Confidence < Threshold)
            {
                _speechController.UnderThresholdNoiseDetected(speechRecognizedEventArgs.Result.Confidence.ToString("P2"));

                return;
            }

            _speechController.HandleSpeech(speechRecognizedEventArgs.Result.Text);
        }
    }
}