//-----------------------------------------------------------------------
// <copyright file="Match.cs" company="Pat Inc.">
//     Copyright (c) Pat Inc. 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace PatTuring2016.Common.ScreenModels
{
    public class Match
    {
        public Match()
        {
            MatchSettings=new MatchSettings();
            Response = string.Empty;
        }

        [Required(ErrorMessage = "A sentence is required")]
        [Display(Name = "Text to match")]
        public string TextIn { get; set; }

        public string UserKey { get; set; }

        public MatchSettings MatchSettings { get; set; }

        public string Response { get; set; }
    }
}