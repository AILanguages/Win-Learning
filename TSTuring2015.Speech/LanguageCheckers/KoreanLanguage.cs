//-----------------------------------------------------------------------
// <copyright file="KoreanLanguage.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TSTuring2015.Speech.LanguageCheckers
{
    using Forms;
    using System.Speech.Recognition;
    using System.Windows.Forms;

    public class KoreanLanguage : AbstractLanguage
    {
        internal override void AddCommands(Choices commands)
        {
            // add language swap commands
            commands.Add("mandarin", "german", "italian");
            commands.Add("cantonese", "french", "australian");
            commands.Add("american", "english", "portuguese");
            commands.Add("spanish", "japanese", "korean");

            // other commands
            commands.Add("target only", "confirm source", "close the program");
            commands.Add("formal", "polite", "intimate", "reset");
            commands.Add("phonetics", "characters", "letters");
        }

        internal override void Reset(Speaker speaker)
        {
            speaker.ResetTarget();
        }

        // return true if we should continue
        internal override bool SpeechIsCommand(string text, Speaker speaker, SpeechController speechController)
        {
            // deal with commands if present
            switch (text)
            {
                case "target only":
                    SetTargetOnly(speaker);
                    return true;
                case "confirm source":
                    SetSourceToo(speaker);
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

                case "close the program":
                    Application.Exit();
                    return true;
            }

            return false;
        }

        protected override void SetSourceToo(Speaker speaker)
        {
            speaker.rbnTargetOnly.Checked = false;
        }

        protected override void SetTargetOnly(Speaker speaker)
        {
            speaker.rbnTargetOnly.Checked = true;
        }
    }
}