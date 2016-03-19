//-----------------------------------------------------------------------
// <copyright file="BaseSyllabus.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PatTuring2016.Speech.VoiceSyllabus
{
    using System.Collections.Generic;

    public class BaseSyllabus
    {
        public BaseSyllabus()
        {
            Commands = new List<string>();
        }

        public string Name { get; set; }

        internal List<string> Commands { set; get; }
    }
}