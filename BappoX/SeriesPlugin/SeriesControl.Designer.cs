namespace SeriesPlugin
{
    partial class SeriesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSeason = new System.Windows.Forms.Label();
            this.numSeason = new System.Windows.Forms.NumericUpDown();
            this.lblEpisode = new System.Windows.Forms.Label();
            this.numEpisode = new System.Windows.Forms.NumericUpDown();
            this.pbOK = new System.Windows.Forms.PictureBox();
            this.pbCancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numSeason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpisode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(47, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(118, 20);
            this.txtName.TabIndex = 9;
            // 
            // lblSeason
            // 
            this.lblSeason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeason.AutoSize = true;
            this.lblSeason.Location = new System.Drawing.Point(171, 6);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(46, 13);
            this.lblSeason.TabIndex = 10;
            this.lblSeason.Text = "Season:";
            // 
            // numSeason
            // 
            this.numSeason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numSeason.AutoSize = true;
            this.numSeason.Location = new System.Drawing.Point(223, 3);
            this.numSeason.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSeason.Name = "numSeason";
            this.numSeason.Size = new System.Drawing.Size(41, 20);
            this.numSeason.TabIndex = 11;
            this.numSeason.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEpisode
            // 
            this.lblEpisode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEpisode.AutoSize = true;
            this.lblEpisode.Location = new System.Drawing.Point(270, 6);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(48, 13);
            this.lblEpisode.TabIndex = 12;
            this.lblEpisode.Text = "Episode:";
            // 
            // numEpisode
            // 
            this.numEpisode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numEpisode.AutoSize = true;
            this.numEpisode.Location = new System.Drawing.Point(324, 3);
            this.numEpisode.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEpisode.Name = "numEpisode";
            this.numEpisode.Size = new System.Drawing.Size(41, 20);
            this.numEpisode.TabIndex = 13;
            this.numEpisode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pbOK
            // 
            this.pbOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbOK.Image = global::SeriesPlugin.Resources.ok;
            this.pbOK.Location = new System.Drawing.Point(371, 3);
            this.pbOK.Name = "pbOK";
            this.pbOK.Size = new System.Drawing.Size(20, 20);
            this.pbOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOK.TabIndex = 7;
            this.pbOK.TabStop = false;
            this.pbOK.Click += new System.EventHandler(this.pbOK_Click);
            // 
            // pbCancel
            // 
            this.pbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCancel.Image = global::SeriesPlugin.Resources.delete;
            this.pbCancel.Location = new System.Drawing.Point(397, 3);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(20, 20);
            this.pbCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCancel.TabIndex = 8;
            this.pbCancel.TabStop = false;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // SeriesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSeason);
            this.Controls.Add(this.numSeason);
            this.Controls.Add(this.lblEpisode);
            this.Controls.Add(this.numEpisode);
            this.Controls.Add(this.pbOK);
            this.Controls.Add(this.pbCancel);
            this.Name = "SeriesControl";
            this.Size = new System.Drawing.Size(420, 26);
            ((System.ComponentModel.ISupportInitialize)(this.numSeason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpisode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.NumericUpDown numSeason;
        private System.Windows.Forms.Label lblEpisode;
        private System.Windows.Forms.NumericUpDown numEpisode;
        private System.Windows.Forms.PictureBox pbOK;
        private System.Windows.Forms.PictureBox pbCancel;

    }
}
