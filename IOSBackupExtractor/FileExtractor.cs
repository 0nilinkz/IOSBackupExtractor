using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IOSBackupExtractor
{
    //Take *Files(Extractable) in TargetDirectory(s) -> rename and copy to DestinationDirectory

    public class FileExtractor
    {
        public BackgroundWorker BackgroundWorker1 { get; set; }
        List<Extractable> Files = new List<Extractable>();
        public int TotalFiles; //UI feedback
        public string TargetDirectory { get; set; }
        public string DestinationDirectory { get; set; }

        int fileCounter = 0; //UI feedback

        public int dupes = 0; //Track duplicate files/files with identical names

        public void AddFile(string name, string path)
        {
            Files.Add(new Extractable(name, path));
        }

        public void ExportFiles()
        {
            //Grab count of files being processed for UI
            TotalFiles = Directory.GetFiles(TargetDirectory, "*", SearchOption.AllDirectories).Length;

            //Find files in the directory
            ProcessDirectory(TargetDirectory);
        }


        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (string fileName in fileEntries)
            {
                //Process files
                if (BackgroundWorker1.CancellationPending)
                {
                    return; //Cancel worker
                }
                ProcessFile(fileName);
            }
                
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public void ProcessFile(string path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            fileCounter++;
            
            //Main logic`
            foreach (Extractable ex in Files)
            {
                if (path.Contains(ex.Name) && file.Exists){

                    //File extension
                    string outname = fileCounter.ToString() + Path.GetFileName(ex.Path);

                    //Create the new directory if required
                    if (!Directory.Exists(DestinationDirectory + ex.Path.TrimEnd(Path.GetFileName(ex.Path).ToCharArray())))
                    {
                        Directory.CreateDirectory(DestinationDirectory + ex.Path.TrimEnd(Path.GetFileName(ex.Path).ToCharArray()));
                    }
                    else
                    {
                        //Copy and rename file to new directory
                        string finalDirectory = DestinationDirectory + ex.Path.TrimEnd(Path.GetFileName(ex.Path).ToCharArray()) + outname;
                        if (!File.Exists(finalDirectory))
                        {
                            file.CopyTo(finalDirectory); 
                        }
                        else
                        {
                            dupes++; //Some duplicate files may exist
                        }
                    }
                    break;
                } 
            }

            //Report progress to UI mabey this could be done less fequently for performance
            int percentage = (int)Math.Round((double)(100 * fileCounter) / TotalFiles);
            BackgroundWorker1.ReportProgress(percentage);
        }
    }

    //A class used to store information recived from sqlite Manifest.db
    class Extractable
    {
        public string Name;
        public string Path;

        public Extractable(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
