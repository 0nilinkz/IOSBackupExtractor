using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace IOSBackupExtractor
{
    public partial class Form1 : Form
    {
        public System.ComponentModel.BackgroundWorker BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            
            //Background worker
            BackgroundWorker1.WorkerReportsProgress = true;
            BackgroundWorker1.WorkerSupportsCancellation = true;

            //UI
            StopExtractionButton.Enabled = false;
            ProvidedButton1.Visible = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            string userprofile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            //Three paths specified by apple 
            //https://support.apple.com/en-au/HT204215
            //Sited 27/10/2020

            string pathA = userprofile + @"\AppData\Roaming\Apple Computer\MobileSync\Backup\";
            string pathB = userprofile + @"\Apple\MobileSync\backup";
            string pathC = userprofile + @"\Apple Computer\MobileSync\backup";
            List<string> possiblePaths = new List<string>();
            possiblePaths.Add(pathA);
            possiblePaths.Add(pathB);
            possiblePaths.Add(pathC);

            //Possible path
            string potentialPath = string.Empty;
            foreach(string path in possiblePaths)
            {
                if (Directory.Exists(path))
                {
                    potentialPath = path;
                    break;
                }
            }

            if (potentialPath != string.Empty)
            {
                BrowserDialog1.SelectedPath = potentialPath;
            }

            BrowserDialog1.ShowDialog();
            BrowserDialog1.Description = "Select IOS backup folder";

            //check if folder actually contains the manifest.db
            if (File.Exists(BrowserDialog1.SelectedPath + @"\Manifest.db"))
            {
                //good
                BackupFolderTextBox.Text = BrowserDialog1.SelectedPath;
                //Update UI
                RequiredButton1.Visible = false;
                ProvidedButton1.Visible = true;
            }
            else
            {
                RequiredButton1.Visible = true;
                ProvidedButton1.Visible = false;
                BackupFolderTextBox.Text = "Unable to find Manifest.db. Please select parent backup folder";
                BrowserDialog1.SelectedPath = string.Empty;
            }
        }

        private void OpenDirectoryButton_Click(object sender, EventArgs e)
        {
            //Opening the Directory externally
            if (DestinationTextBox.Text != string.Empty)
            {
                Process.Start("explorer.exe", DestinationTextBox.Text + @"\");
            }
        }

        private void DestinationButton_Click(object sender, EventArgs e)
        {
            BrowserDialog2.ShowDialog();
            BrowserDialog2.Description = "Select Destination Folder";

            DestinationTextBox.Text = BrowserDialog2.SelectedPath;

            //Update UI
            if (DestinationTextBox.Text != string.Empty)
            {
                RequiredButton2.Visible = false;
            }
            else
            {
                RequiredButton2.Visible = true;
            }

        }

        private void ExtractionButton_Click(object sender, EventArgs e)
        {
            //Check directorys have been provided!
            if (BrowserDialog1.SelectedPath != string.Empty && BrowserDialog2.SelectedPath != string.Empty)
            {
                BackgroundWorker1.DoWork += ProduceExtractedFiles;
                BackgroundWorker1.ProgressChanged += bgw_ProgressChanged;
                BackgroundWorker1.RunWorkerCompleted += bgw_RunWorkerCompleted;
                BackgroundWorker1.RunWorkerAsync();

                //Disable UI components when running
                ExtractionButton.Enabled = false;
                StopExtractionButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Backup and save location folders Must be provided.");
            }
        }

        private void StopExtractionButton_Click(object sender, EventArgs e)
        {
            //Stop the background worker
            BackgroundWorker1.CancelAsync();
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Update UI on progress
            int Progress = e.ProgressPercentage;
            if (Progress > 0)
            {
                FileCountLabel.Text = Progress.ToString();
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = Progress;
            }
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Job completed/canceled
            //Reset UI components
            StopExtractionButton.Enabled = false;
            ExtractionButton.Enabled = true;
            progressBar1.Value = 0;
            FileCountLabel.Text = "0";
        }

        //IOS backup files consist of an SQLite DB titled Manifest.db
        public void ProduceExtractedFiles(object sender, DoWorkEventArgs e)
        {
            //Provided directory for manifest.
            string cs = "Data Source=" + BackupFolderTextBox.Text.ToString() + @"\Manifest.db";
            string stm = "select * from Files";

            if (!File.Exists(BackupFolderTextBox.Text.ToString() + @"\Manifest.db")){
                MessageBox.Show("Error: Unable to execute, missing manifest");
                return;
            }
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(stm, con);

            FileExtractor fileExtractor = new FileExtractor();
            fileExtractor.TargetDirectory = BackupFolderTextBox.Text; //Path containing parent backup folder this should contain a sqlite manifest file
            fileExtractor.DestinationDirectory = DestinationTextBox.Text + @"\"; //Destination Directory set via user
            fileExtractor.BackgroundWorker1 = BackgroundWorker1; //for reporting progress for UI
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                // 0 contains obfusicated file name, and 1 contains the actual path (actual file name inclusive)
                // Produced from Itunes Version 12.10.9.3 on an Iphone X (10/2020)
                fileExtractor.AddFile(rdr.GetString(0), rdr.GetString(2));
            }

            //Close and dispose of SQLite instances
            rdr.Close();
            rdr.DisposeAsync();
            con.Close();
            con.Dispose();

            //Proceess Files
            fileExtractor.ExportFiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
