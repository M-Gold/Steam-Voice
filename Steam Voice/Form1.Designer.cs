namespace Steam_Voice
{
    partial class Form1
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
            this.tbSteamID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butStart = new System.Windows.Forms.Button();
            this.gbStart = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSteamID
            // 
            this.tbSteamID.Location = new System.Drawing.Point(63, 31);
            this.tbSteamID.Name = "tbSteamID";
            this.tbSteamID.Size = new System.Drawing.Size(100, 20);
            this.tbSteamID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Steam ID";
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(47, 57);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(75, 23);
            this.butStart.TabIndex = 2;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStartClicked);
            // 
            // gbStart
            // 
            this.gbStart.Controls.Add(this.butStart);
            this.gbStart.Controls.Add(this.label1);
            this.gbStart.Controls.Add(this.tbSteamID);
            this.gbStart.Location = new System.Drawing.Point(-6, -6);
            this.gbStart.Name = "gbStart";
            this.gbStart.Size = new System.Drawing.Size(204, 126);
            this.gbStart.TabIndex = 3;
            this.gbStart.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(0, 32);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(173, 23);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Waiting";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(162, 109);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gbStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbStart.ResumeLayout(false);
            this.gbStart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbSteamID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.GroupBox gbStart;
        public System.Windows.Forms.Label lblStatus;


    }
}

