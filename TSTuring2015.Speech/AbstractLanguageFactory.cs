//-----------------------------------------------------------------------
// <copyright file="AbstractLanguageFactory.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TSTuring2015.Speech
{
    using LanguageCheckers;

    public class AbstractLanguageFactory
    {
        internal static AbstractLanguage GetFactory(string text, AbstractLanguage current)
        {
            switch (text)
            {
                case "japanese":
                    return new JapaneseLanguage { ContextForm = current.ContextForm };

                case "korean":
                    return new KoreanLanguage { ContextForm = current.ContextForm };

                default:
                    return current;
            }
        }
    }
}