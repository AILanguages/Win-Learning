//-----------------------------------------------------------------------
// <copyright file="FindSettings.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using PatTuring2016.Common;
using PatTuring2016.Common.ScreenModels;
using PatTuring2016.Speech.Forms;
using System;

namespace PatTuring2016.Speech.Validation
{
    public class FindSettings
    {
        public FindSettings()
        {
            MatchSettings = new MatchSettings();
        }

        public MatchSettings MatchSettings { get; }

        public void Update(string target, ContextForm contextForm)
        {
            MatchSettings.ShowSentences = false; // we don't use for translation at the moment

            MatchSettings.IllocutionaryForce = IllocutionaryForce.Source;

            CheckDisplay(contextForm);
            CheckFormality(contextForm, target);
            CheckChangePerson(contextForm);
            CheckChangeIForce(contextForm);

            try
            {
                var targetValue = (TargetLanguages)Enum.Parse(typeof(TargetLanguages), target);
                if (Enum.IsDefined(typeof(TargetLanguages), targetValue))
                {
                    MatchSettings.TargetLanguage = targetValue == TargetLanguages.Cantonese ? TargetLanguages.Mandarin : targetValue;
                }
            }
            catch (Exception)
            {
                MatchSettings.TargetLanguage = TargetLanguages.German; // major error                 
            }
        }

        private void CheckDisplay(ContextForm contextForm)
        {
            switch (contextForm.cbxDisplay.Text)
            {
                case "Letters":
                    MatchSettings.Characters = Display.Letters;
                    break;
                case "Phonetics":
                    MatchSettings.Characters = Display.Phonetics;
                    break;
                default:
                    MatchSettings.Characters = Display.Characters;
                    break;
            }
        }

        private void CheckFormality(ContextForm contextForm, string target)
        {
            var formality = contextForm.cbxFormality.Text;
            var polite = contextForm.cbxPolite.Text;

            if (target == "Korean")
            {
                if (formality == "High") // formal
                {
                    MatchSettings.Formal = Formalities.High;
                    MatchSettings.Polite = Politeness.Neutral;
                    return;
                }
                if (polite == "Low") // intimate
                {
                    MatchSettings.Polite = Politeness.Low;
                    MatchSettings.Formal = Formalities.Neutral;
                    return;
                }

                // defaults
                MatchSettings.Polite = Politeness.Neutral;
                MatchSettings.Formal = Formalities.Neutral;
                return;
            }

            if (target == "Japanese")
            {
                if (polite == "Low") // intimate
                {
                    MatchSettings.Polite = Politeness.Low;
                    MatchSettings.Formal = Formalities.Neutral;
                    return;
                }
                if (formality == "Neutral")
                {
                    MatchSettings.Polite = Politeness.Neutral;
                    MatchSettings.Formal = Formalities.Neutral;
                    return;
                }
            }

            // defaults = polite
            MatchSettings.Polite = Politeness.Neutral;
            if (formality == "High")
            {
                MatchSettings.Formal = Formalities.High;
            }
            else
            {
                MatchSettings.Formal = Formalities.Neutral;
            }
        }

        private void CheckChangePerson(ContextForm contextForm)
        {
            if (contextForm.cbxPersonChange.Text == "Source")
            {
                MatchSettings.PersonChange = PersonChange.Source;
                return;
            }

            if (contextForm.cbxPersonChange.Text == PersonChange.OneToOne1PSg.ToString())
            {
                MatchSettings.PersonChange = PersonChange.OneToOne1PSg;
                return;
            }

            if (contextForm.cbxPersonChange.Text == PersonChange.OneToMany2PPl.ToString())
            {
                MatchSettings.PersonChange = PersonChange.OneToMany2PPl;
                return;
            }

            if (contextForm.cbxPersonChange.Text == PersonChange.WithMe1PPl.ToString())
            {
                MatchSettings.PersonChange = PersonChange.WithMe1PPl;
            }
        }

        private void CheckChangeIForce(ContextForm contextForm)
        {
            switch (contextForm.cbxIForce.Text)
            {
                case "Imperative":
                    MatchSettings.IllocutionaryForce = IllocutionaryForce.Imperative;
                    break;

                case "Question":
                    MatchSettings.IllocutionaryForce = IllocutionaryForce.Question;
                    break;

                case "Statement":
                    MatchSettings.IllocutionaryForce = IllocutionaryForce.Statement;
                    break;

                default:
                    MatchSettings.IllocutionaryForce = IllocutionaryForce.Source;
                    break;
            }
        }
    }
}
