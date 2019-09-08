using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace anti_ransomware
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFixAtr_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                string[] allfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                string[] directories = Directory.GetDirectories(path,"*",SearchOption.AllDirectories);
 
                if (allfiles != null)
                {
                    if (allfiles.Length != 0)
                    {
                        foreach (string currentFile in allfiles)
                        {
                            try
                            {
                                File.SetAttributes(currentFile, FileAttributes.Normal);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("The process failed: {0} for {1}", ex.StackTrace, currentFile);
                            }
                        }

                        foreach (string currentFile in directories)
                        {
                            try
                            {
                                File.SetAttributes(currentFile, FileAttributes.Normal);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("The process failed: {0} for {1}", ex.StackTrace, currentFile);
                            }
                        }

                        MessageBox.Show("Done!", "Operation Successful");
                    }
                    else
                    {
                        MessageBox.Show("Nothing To Fix");
                    }
                }
                else
                {
                    MessageBox.Show("Nothing To Fix");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error");
                Console.WriteLine("The process failed: {0}", ex.StackTrace);
            }
        }

        private void btnFixPath_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                string target = path + "\\fixed";
                string[] allfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                if (allfiles != null)
                {
                    if (allfiles.Length != 0)
                    {
                        foreach (string currentFile in allfiles)
                        {
                            try
                            {
                                string fName = Path.GetFileNameWithoutExtension(currentFile);
                                string ext = Path.GetExtension(currentFile);
                                string dest = Path.Combine(target, fName + ext);
                                if (Path.GetFileName(currentFile).Equals(System.AppDomain.CurrentDomain.FriendlyName) 
                                    || Path.GetDirectoryName(currentFile).Equals(target) 
                                    || Path.GetDirectoryName(currentFile).Equals(path))
                                {
                                    continue;
                                }

                                if (File.Exists(dest))
                                {
                                    File.Move(currentFile, MakeUnique(dest));
                                }
                                else
                                {
                                    string dir = Path.GetDirectoryName(dest);
                                    if (!Directory.Exists(dir))
                                    {
                                        Directory.CreateDirectory(dir);
                                    }
                                    
                                    File.Move(currentFile, dest);
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("The process failed: {0} for {1}", ex.StackTrace, currentFile);
                            }
                        }
                        CleanUpEmptyDirectories(path);
                        MessageBox.Show("Done!", "Operation Successful");
                    }
                    else
                    {
                        MessageBox.Show("Nothing To Fix", "Operation Successful");
                    }
                }
                else
                {
                    MessageBox.Show("Nothing To Fix","Operation Successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace,"Error");
                Console.WriteLine("The process failed: {0}", ex.StackTrace);
            }
        }

        public string MakeUnique(string path)
        {
            string extension = Path.GetExtension(path);
            string pathName = Path.GetDirectoryName(path);
            string fileNameOnly = Path.Combine(pathName, Path.GetFileNameWithoutExtension(path));
            int i = 1;

            while (File.Exists(path))
            {
                path = string.Format("{0} ({1}){2}", fileNameOnly, i++, extension);
            }
            return path;
        }

        public void CleanUpEmptyDirectories(string path)
        {
            string[] dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                if (!Directory.Exists(dir)) continue;
                string[] files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                if (files.Length == 0)
                {
                    DeleteRecursively(dir);
                }
            }
        }

        private void DeleteRecursively(string destinationDir)
        {
            const int md = 10;
            for (var gnm = 1; gnm <= md; gnm++)
            {
                try
                {
                    Directory.Delete(destinationDir, true);
                }
                catch (DirectoryNotFoundException)
                {
                    return; 
                }
                catch (IOException)
                { 
                    System.Diagnostics.Debug.WriteLine("Deletion of {0} failed! attempt #{1}.", destinationDir, gnm);
                    Thread.Sleep(50);
                    continue;
                }
                return;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}
