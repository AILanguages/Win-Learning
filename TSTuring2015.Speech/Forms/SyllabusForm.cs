//-----------------------------------------------------------------------
// <copyright file="SyllabusForm.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TSTuring2015.Speech.Forms
{
    using System;
    using System.Windows.Forms;
    using VoiceSyllabus;

    public partial class SyllabusForm : Form
    {
        private SpeechController _speechController;
        private SyllabusTracker _syllabusTracker;

        public SyllabusForm()
        {
            InitializeComponent();
        }

        public void Setup(SpeechController speechController, SyllabusTracker syllabusTracker)
        {
            _speechController = speechController;
            _syllabusTracker = syllabusTracker;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var currentSyllabus = GetSyllabusFile.OpenFile();

            if (string.IsNullOrWhiteSpace(currentSyllabus.Name)) return;

            _speechController.AddSyllabus(currentSyllabus);

            if (string.IsNullOrWhiteSpace(tbxSyllabus.Text))
            {
                tbxSyllabus.Text = GetFileNameOnly(currentSyllabus.Name);
            }
            else
            {
                tbxSyllabus.Text = GetFileNameOnly(currentSyllabus.Name) + ", " + tbxSyllabus.Text;
            }

            _speechController.LoadSyllabus();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            _speechController.ClearTextBoxes();
            _speechController.SayLast();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            _speechController.ClearTextBoxes();
            _speechController.OnDisplayRequested();
        }

        private void btnSyllabus_Click(object sender, EventArgs e)
        {
            _speechController.ClearTextBoxes();
            _speechController.OnSyllabusSelected();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _syllabusTracker.ResetSyllabi();
            tbxSyllabus.Text = string.Empty;
        }

        private string GetFileNameOnly(string name)
        {
            return name.EndsWith(".txt") ? name.Substring(0, name.Length - 4) : name;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
