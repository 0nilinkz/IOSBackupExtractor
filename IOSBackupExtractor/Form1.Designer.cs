namespace IOSBackupExtractor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.FileCountLabel = new System.Windows.Forms.Label();
            this.BrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.DestinationButton = new System.Windows.Forms.Button();
            this.ExtractionButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BackupFolderTextBox = new System.Windows.Forms.TextBox();
            this.DestinationTextBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.BrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.StopExtractionButton = new System.Windows.Forms.Button();
            this.OpenDirectoryButton1 = new System.Windows.Forms.Button();
            this.RequiredButton1 = new System.Windows.Forms.Button();
            this.RequiredButton2 = new System.Windows.Forms.Button();
            this.ProvidedButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "%";
            // 
            // FileCountLabel
            // 
            this.FileCountLabel.AutoSize = true;
            this.FileCountLabel.Location = new System.Drawing.Point(263, 172);
            this.FileCountLabel.Name = "FileCountLabel";
            this.FileCountLabel.Size = new System.Drawing.Size(13, 15);
            this.FileCountLabel.TabIndex = 0;
            this.FileCountLabel.Text = "0";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Image = ((System.Drawing.Image)(resources.GetObject("BrowseButton.Image")));
            this.BrowseButton.Location = new System.Drawing.Point(8, 26);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(29, 24);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // DestinationButton
            // 
            this.DestinationButton.Image = ((System.Drawing.Image)(resources.GetObject("DestinationButton.Image")));
            this.DestinationButton.Location = new System.Drawing.Point(8, 107);
            this.DestinationButton.Name = "DestinationButton";
            this.DestinationButton.Size = new System.Drawing.Size(29, 24);
            this.DestinationButton.TabIndex = 1;
            this.DestinationButton.UseVisualStyleBackColor = true;
            this.DestinationButton.Click += new System.EventHandler(this.DestinationButton_Click);
            // 
            // ExtractionButton
            // 
            this.ExtractionButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ExtractionButton.Image = ((System.Drawing.Image)(resources.GetObject("ExtractionButton.Image")));
            this.ExtractionButton.Location = new System.Drawing.Point(42, 190);
            this.ExtractionButton.Name = "ExtractionButton";
            this.ExtractionButton.Size = new System.Drawing.Size(30, 28);
            this.ExtractionButton.TabIndex = 2;
            this.ExtractionButton.UseVisualStyleBackColor = true;
            this.ExtractionButton.Click += new System.EventHandler(this.ExtractionButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select Backup to extract";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Save Location";
            // 
            // BackupFolderTextBox
            // 
            this.BackupFolderTextBox.Location = new System.Drawing.Point(43, 27);
            this.BackupFolderTextBox.Name = "BackupFolderTextBox";
            this.BackupFolderTextBox.ReadOnly = true;
            this.BackupFolderTextBox.Size = new System.Drawing.Size(452, 23);
            this.BackupFolderTextBox.TabIndex = 4;
            // 
            // DestinationTextBox
            // 
            this.DestinationTextBox.Location = new System.Drawing.Point(43, 108);
            this.DestinationTextBox.Name = "DestinationTextBox";
            this.DestinationTextBox.ReadOnly = true;
            this.DestinationTextBox.Size = new System.Drawing.Size(452, 23);
            this.DestinationTextBox.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(78, 190);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(379, 28);
            this.progressBar1.TabIndex = 5;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(202, 172);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(55, 15);
            this.ProgressLabel.TabIndex = 6;
            this.ProgressLabel.Text = "Progress:";
            // 
            // StopExtractionButton
            // 
            this.StopExtractionButton.Image = ((System.Drawing.Image)(resources.GetObject("StopExtractionButton.Image")));
            this.StopExtractionButton.Location = new System.Drawing.Point(463, 190);
            this.StopExtractionButton.Name = "StopExtractionButton";
            this.StopExtractionButton.Size = new System.Drawing.Size(30, 28);
            this.StopExtractionButton.TabIndex = 2;
            this.StopExtractionButton.UseVisualStyleBackColor = true;
            this.StopExtractionButton.Click += new System.EventHandler(this.StopExtractionButton_Click);
            // 
            // OpenDirectoryButton1
            // 
            this.OpenDirectoryButton1.Image = ((System.Drawing.Image)(resources.GetObject("OpenDirectoryButton1.Image")));
            this.OpenDirectoryButton1.Location = new System.Drawing.Point(532, 108);
            this.OpenDirectoryButton1.Name = "OpenDirectoryButton1";
            this.OpenDirectoryButton1.Size = new System.Drawing.Size(25, 23);
            this.OpenDirectoryButton1.TabIndex = 1;
            this.OpenDirectoryButton1.UseVisualStyleBackColor = true;
            this.OpenDirectoryButton1.Click += new System.EventHandler(this.OpenDirectoryButton_Click);
            // 
            // RequiredButton1
            // 
            this.RequiredButton1.Image = ((System.Drawing.Image)(resources.GetObject("RequiredButton1.Image")));
            this.RequiredButton1.Location = new System.Drawing.Point(501, 26);
            this.RequiredButton1.Name = "RequiredButton1";
            this.RequiredButton1.Size = new System.Drawing.Size(26, 24);
            this.RequiredButton1.TabIndex = 8;
            this.RequiredButton1.UseVisualStyleBackColor = true;
            // 
            // RequiredButton2
            // 
            this.RequiredButton2.Image = ((System.Drawing.Image)(resources.GetObject("RequiredButton2.Image")));
            this.RequiredButton2.Location = new System.Drawing.Point(501, 108);
            this.RequiredButton2.Name = "RequiredButton2";
            this.RequiredButton2.Size = new System.Drawing.Size(25, 23);
            this.RequiredButton2.TabIndex = 8;
            this.RequiredButton2.UseVisualStyleBackColor = true;
            // 
            // ProvidedButton1
            // 
            this.ProvidedButton1.Image = ((System.Drawing.Image)(resources.GetObject("ProvidedButton1.Image")));
            this.ProvidedButton1.Location = new System.Drawing.Point(533, 26);
            this.ProvidedButton1.Name = "ProvidedButton1";
            this.ProvidedButton1.Size = new System.Drawing.Size(24, 24);
            this.ProvidedButton1.TabIndex = 8;
            this.ProvidedButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 239);
            this.Controls.Add(this.ProvidedButton1);
            this.Controls.Add(this.RequiredButton2);
            this.Controls.Add(this.RequiredButton1);
            this.Controls.Add(this.OpenDirectoryButton1);
            this.Controls.Add(this.StopExtractionButton);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.DestinationTextBox);
            this.Controls.Add(this.BackupFolderTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExtractionButton);
            this.Controls.Add(this.DestinationButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.FileCountLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "IOS Backup Extractor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog BrowserDialog1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button DestinationButton;
        private System.Windows.Forms.Button ExtractionButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BackupFolderTextBox;
        private System.Windows.Forms.TextBox DestinationTextBox;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.FolderBrowserDialog BrowserDialog2;
        private System.Windows.Forms.Label FileCountLabel;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button StopExtractionButton;
        private System.Windows.Forms.Button OpenDirectoryButton1;
        private System.Windows.Forms.Button RequiredButton1;
        private System.Windows.Forms.Button RequiredButton2;
        private System.Windows.Forms.Button ProvidedButton1;
    }
}

