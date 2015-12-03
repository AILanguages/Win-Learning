//-----------------------------------------------------------------------
// <copyright file="VoiceCommands.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TSTuring2015.Speech.SpeechRec
{
    using System.Speech.Recognition;

    public class VoiceCommands
    {
        internal static void AddCommands(Choices commands)
        {
            // add language swap commands
            commands.Add("mandarin", "german", "italian");
            commands.Add("cantonese", "french", "australian");
            commands.Add("american", "english", "portuguese");
            commands.Add("spanish", "japanese", "korean");

            // other commands
            commands.Add("target only", "confirm source", "close the program");
            commands.Add("formal", "polite", "intimate");
            commands.Add("phonetics", "characters", "letters");
        }
    }
}