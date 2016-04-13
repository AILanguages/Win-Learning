//-----------------------------------------------------------------------
// <copyright file="Speaker.cs" company="Thinking Solutions Pty Ltd">
//     Copyright (c) Thinking Solutions 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Windows.Forms;
using PatTuring2016.Common;
using PatTuring2016.Common.ScreenModels;
using StructureMap;

namespace PatTuring2016.Speech.Forms
{
    public partial class Speaker : Form
    {
        private SpeechController _speechController;
        
        public Speaker()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            var languages = AllLanguages.LanguageObjectList();

            ckLstTargets.Items.AddRange(languages);

            SetSingleLanguage(AllLanguageList.German);

            cbxSource.Items.AddRange(languages);
            cbxSource.Text = AllLanguageList.OzEnglish.ToString(); // default source speaker
        }

        internal void SetSingleLanguage(AllLanguageList single)
        {
            for (var i = 0; i < ckLstTargets.Items.Count; i++)
            {
                if (ckLstTargets.Items[i].ToString() == single.ToString())
                {
                    ckLstTargets.SetItemChecked(i, true);
                }
            }
        }

        internal string GetSingleLanguage()
        {
            foreach (var language in ckLstTargets.CheckedItems)
            {
                return language.ToString();
            }

            return string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var splash = new SettingsForm();
            splash.ShowDialog();

            if (splash.Error)
            {
                Close();
            }
        }

        private SpeechController GetSpeechController()
        {
            if (_speechController == null)
            {
                var container = new Container();
                _speechController = container.GetInstance<SpeechController>();
                _speechController.Setup(this);
            }

            return _speechController;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            GetSpeechController().SetVoiceMonitoring();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            GetSpeechController().StopRecognize();

            lblError.Text = string.Empty;
            lblErrorSound.Text = string.Empty;
            lblPercent.Text = string.Empty;
        }

        internal void ResetTarget()
        {
            for (var i = 0; i < ckLstTargets.Items.Count; i++)
            {
                ckLstTargets.SetItemChecked(i, false);
            }
        }

        private void btnQuiet_Click(object sender, EventArgs e)
        {
            GetSpeechController().SetQuiet();
        }

        private void btnTextEntry_Click(object sender, EventArgs e)
        {
            GetSpeechController().HandleSpeech(tbxEntry.Text);
        }

        private void btnGoOnline_Click(object sender, EventArgs e)
        {
            var speechcontroller = GetSpeechController();
            speechcontroller.CloseWindows();
            _speechController = null;
            Form1_Load(this, new EventArgs());
            GetSpeechController(); // reset speech controller and links 
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            GetSpeechController().MoreContext();
        }

        private void rdAccentOnly_Clicked(object sender, EventArgs e)
        {
            rdAccentOnly.Checked = !rdAccentOnly.Checked;
        }

        private void rbnTargetOnly_Clicked(object sender, EventArgs e)
        {
            rbnTargetOnly.Checked = !rbnTargetOnly.Checked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}