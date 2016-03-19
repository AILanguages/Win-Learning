namespace PatTuring2016.Speech.Forms
{
    partial class Speaker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rdAccentOnly = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSource = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.rbnTargetOnly = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblErrorSound = new System.Windows.Forms.Label();
            this.btnQuiet = new System.Windows.Forms.Button();
            this.tbxEntry = new System.Windows.Forms.TextBox();
            this.btnTextIn = new System.Windows.Forms.Button();
            this.ckLstTargets = new System.Windows.Forms.CheckedListBox();
            this.btnGoOnline = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(9, 47);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(613, 412);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox2.Location = new System.Drawing.Point(642, 47);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(722, 412);
            this.textBox2.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStart.Location = new System.Drawing.Point(12, 576);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(215, 69);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "listen now";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Speech Heard";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(674, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Spoken Translation";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStop.Location = new System.Drawing.Point(12, 663);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(215, 69);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "don\'t listen";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(636, 655);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Target Language";
            // 
            // rdAccentOnly
            // 
            this.rdAccentOnly.AutoCheck = false;
            this.rdAccentOnly.AutoSize = true;
            this.rdAccentOnly.Location = new System.Drawing.Point(646, 692);
            this.rdAccentOnly.Margin = new System.Windows.Forms.Padding(2);
            this.rdAccentOnly.Name = "rdAccentOnly";
            this.rdAccentOnly.Size = new System.Drawing.Size(119, 24);
            this.rdAccentOnly.TabIndex = 8;
            this.rdAccentOnly.Text = "Accent Only";
            this.rdAccentOnly.UseVisualStyleBackColor = true;
            this.rdAccentOnly.Click += new System.EventHandler(this.rdAccentOnly_Clicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(636, 538);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(349, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Source Language / Accent";
            // 
            // cbxSource
            // 
            this.cbxSource.FormattingEnabled = true;
            this.cbxSource.Location = new System.Drawing.Point(642, 608);
            this.cbxSource.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSource.Name = "cbxSource";
            this.cbxSource.Size = new System.Drawing.Size(440, 28);
            this.cbxSource.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Tomato;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(9, 836);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(215, 69);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "close app";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rbnTargetOnly
            // 
            this.rbnTargetOnly.AutoCheck = false;
            this.rbnTargetOnly.AutoSize = true;
            this.rbnTargetOnly.Location = new System.Drawing.Point(646, 576);
            this.rbnTargetOnly.Margin = new System.Windows.Forms.Padding(2);
            this.rbnTargetOnly.Name = "rbnTargetOnly";
            this.rbnTargetOnly.Size = new System.Drawing.Size(165, 24);
            this.rbnTargetOnly.TabIndex = 12;
            this.rbnTargetOnly.Text = "Speak Target Only";
            this.rbnTargetOnly.UseVisualStyleBackColor = true;
            this.rbnTargetOnly.Click += new System.EventHandler(this.rbnTargetOnly_Clicked);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.CadetBlue;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(1149, 463);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(215, 69);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(22, 780);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 20);
            this.lblError.TabIndex = 19;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(22, 751);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(0, 20);
            this.lblPercent.TabIndex = 23;
            // 
            // lblErrorSound
            // 
            this.lblErrorSound.AutoSize = true;
            this.lblErrorSound.Location = new System.Drawing.Point(22, 942);
            this.lblErrorSound.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorSound.Name = "lblErrorSound";
            this.lblErrorSound.Size = new System.Drawing.Size(0, 20);
            this.lblErrorSound.TabIndex = 24;
            // 
            // btnQuiet
            // 
            this.btnQuiet.BackColor = System.Drawing.Color.Pink;
            this.btnQuiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnQuiet.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnQuiet.Location = new System.Drawing.Point(231, 663);
            this.btnQuiet.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuiet.Name = "btnQuiet";
            this.btnQuiet.Size = new System.Drawing.Size(215, 69);
            this.btnQuiet.TabIndex = 25;
            this.btnQuiet.Text = "be silent";
            this.btnQuiet.UseVisualStyleBackColor = false;
            this.btnQuiet.Click += new System.EventHandler(this.btnQuiet_Click);
            // 
            // tbxEntry
            // 
            this.tbxEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEntry.Location = new System.Drawing.Point(12, 476);
            this.tbxEntry.Name = "tbxEntry";
            this.tbxEntry.Size = new System.Drawing.Size(610, 39);
            this.tbxEntry.TabIndex = 27;
            // 
            // btnTextIn
            // 
            this.btnTextIn.BackColor = System.Drawing.Color.SeaGreen;
            this.btnTextIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTextIn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTextIn.Location = new System.Drawing.Point(642, 463);
            this.btnTextIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnTextIn.Name = "btnTextIn";
            this.btnTextIn.Size = new System.Drawing.Size(215, 69);
            this.btnTextIn.TabIndex = 28;
            this.btnTextIn.Text = "enter";
            this.btnTextIn.UseVisualStyleBackColor = false;
            this.btnTextIn.Click += new System.EventHandler(this.btnTextEntry_Click);
            // 
            // ckLstTargets
            // 
            this.ckLstTargets.CheckOnClick = true;
            this.ckLstTargets.FormattingEnabled = true;
            this.ckLstTargets.Location = new System.Drawing.Point(643, 724);
            this.ckLstTargets.Name = "ckLstTargets";
            this.ckLstTargets.Size = new System.Drawing.Size(439, 214);
            this.ckLstTargets.Sorted = true;
            this.ckLstTargets.TabIndex = 35;
            // 
            // btnGoOnline
            // 
            this.btnGoOnline.BackColor = System.Drawing.Color.Black;
            this.btnGoOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnGoOnline.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGoOnline.Location = new System.Drawing.Point(1149, 555);
            this.btnGoOnline.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoOnline.Name = "btnGoOnline";
            this.btnGoOnline.Size = new System.Drawing.Size(215, 69);
            this.btnGoOnline.TabIndex = 36;
            this.btnGoOnline.Text = "change server";
            this.btnGoOnline.UseVisualStyleBackColor = false;
            this.btnGoOnline.Click += new System.EventHandler(this.btnGoOnline_Click);
            // 
            // btnMore
            // 
            this.btnMore.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnMore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMore.Location = new System.Drawing.Point(1149, 647);
            this.btnMore.Margin = new System.Windows.Forms.Padding(2);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(215, 69);
            this.btnMore.TabIndex = 41;
            this.btnMore.Text = "more settings";
            this.btnMore.UseVisualStyleBackColor = false;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 538);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 32);
            this.label5.TabIndex = 42;
            this.label5.Text = "Voice";
            // 
            // Speaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1375, 974);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.btnGoOnline);
            this.Controls.Add(this.ckLstTargets);
            this.Controls.Add(this.btnTextIn);
            this.Controls.Add(this.tbxEntry);
            this.Controls.Add(this.btnQuiet);
            this.Controls.Add(this.lblErrorSound);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rbnTargetOnly);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbxSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdAccentOnly);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Speaker";
            this.Text = "Speech Translator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.ComboBox cbxSource;
        internal System.Windows.Forms.RadioButton rdAccentOnly;
        internal System.Windows.Forms.RadioButton rbnTargetOnly;
        internal System.Windows.Forms.Label lblError;
        internal System.Windows.Forms.Label lblPercent;
        internal System.Windows.Forms.Label lblErrorSound;
        private System.Windows.Forms.Button btnQuiet;
        private System.Windows.Forms.TextBox tbxEntry;
        private System.Windows.Forms.Button btnTextIn;
        internal System.Windows.Forms.CheckedListBox ckLstTargets;
        private System.Windows.Forms.Button btnGoOnline;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Label label5;
    }
}

