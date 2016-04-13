//-----------------------------------------------------------------------
// <copyright file="ContextForm.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using PatTuring2016.Common;
using PatTuring2016.Common.ScreenModels;
using PatTuring2016.Speech.Validation;
using System;
using System.Windows.Forms;

namespace PatTuring2016.Speech.Forms
{
    public partial class ContextForm : Form
    {
        private readonly FindSettings _findSettings;

        public ContextForm()
        {
            InitializeComponent();
            MatchSettings = new MatchSettings();
            _findSettings = new FindSettings();
        }

        public MatchSettings MatchSettings { get; set; }
        
        private void btnHide_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        internal void Setup()
        {
            cbxDisplay.Text = Display.Letters.ToString();
            cbxIForce.Text = IllocutionaryForce.Source.ToString();
            cbxRelations.Visible = true;
            cbxRelations.Text = "EqualStatus";

            lblSpkRelations.Visible = true;

            cbxSourceGender.Items.AddRange(AllGenders.GenderObjectList());
            cbxSourceGender.Text = AllGendersList.Male.ToString(); // default male speaker

            cbxTargetGender.Items.AddRange(AllGenders.GenderObjectList());
            cbxTargetGender.Text = AllGendersList.Female.ToString(); // default female target listener

            cbxPersonChange.Items.AddRange(AllPersonChangeList.PersonChangeObjectList());
            cbxPersonChange.Text = PersonChange.Source.ToString();

            cbxFormality.Items.AddRange(AllFormalList.FormalObjectList());
            cbxFormality.Text = Formalities.Neutral.ToString();

            cbxPolite.Items.AddRange(AllPoliteList.FormalObjectList());
            cbxPolite.Text = Politeness.Neutral.ToString();
        }
    }
}