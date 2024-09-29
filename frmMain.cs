using MountBladeModPacker;
using System.ComponentModel;
using System.Diagnostics;

namespace MountBladeModulePacker
{
    public partial class frmMain : Form
    {
        private List<FolderFile> excludedFileFolders;

        public frmMain()
        {
            InitializeComponent();
            excludedFileFolders = new List<FolderFile>();
        }

        private void btnBrowseModBaseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = dialog.SelectedPath.Replace("\\", "/");
                if(File.Exists(Path.Combine(folderPath, "module.ini")))
                {
                    //Valid folder
                    txtModBaseDir.Text = folderPath;

                    excludedFileFolders.Clear();
                    listModExcludeList.Items.Clear();
                    btnAddModExcludeItem.Enabled = true;
                    btnRemoveModExcludeItem.Enabled = false;

                    btnSaveProfile.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid Mount&Blade Mod Path!", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Invalid folder, clear the path
                    txtModBaseDir.Text = null;

                    btnSaveProfile.Enabled = false;
                }
            }
        }

        private void btnBrowseModSavePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Archive File|*.7z";
            if(dialog.ShowDialog() == DialogResult.OK ) 
            {
                txtModSavePath.Text = dialog.FileName.Replace("\\", "/");
                btnStartPack.Enabled = true;
            }
        }

        private void btnAddModExcludeItem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtModBaseDir.Text))
            {
                frmFileFolder fileFolderWin = new frmFileFolder(txtModBaseDir.Text);
                if(fileFolderWin.ShowDialog() == DialogResult.OK)
                {
                    var fileFolder = fileFolderWin.SelectedFolderFile;
                    if(!isContainInExculdeList(fileFolder))
                    {
                        excludedFileFolders.Add(fileFolder);

                        ListViewItem item = new ListViewItem();
                        item.Text = fileFolder.Name;
                        item.SubItems.Add(fileFolder.Type.ToString());
                        listModExcludeList.Items.Add(item);
                    }
                    else
                    {
                        MessageBox.Show("The exculded folder/file has already existed in the list!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnAddModExcludeItem_Click(sender, e);
                    }
                }
            }
        }

        private bool isContainInExculdeList(FolderFile fileFolder)
        {
            foreach(var item in excludedFileFolders)
            {
                if(item.Name == fileFolder.Name && item.Type == fileFolder.Type)
                { 
                    return true; 
                }
            }
            return false;
        }

        private void btnRemoveModExcludeItem_Click(object sender, EventArgs e)
        {
            if(listModExcludeList.SelectedIndices.Count > 0)
            {
                listModExcludeList.Items.RemoveAt(listModExcludeList.SelectedIndices[0]);
            }
        }

        private void listModExcludeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listModExcludeList.SelectedItems.Count > 0)
            {
                btnRemoveModExcludeItem.Enabled = true;
            }
            else
            {
                btnRemoveModExcludeItem.Enabled = false;
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string baseDir = txtModBaseDir.Text;

            DirectoryInfo saveFileFullPathInfo = new DirectoryInfo(txtModSavePath.Text);
            if (saveFileFullPathInfo != null)
            {
                string saveFileDir = saveFileFullPathInfo.Parent.FullName;

                DirectoryInfo baseDirInfo = new DirectoryInfo(baseDir);
                string baseDirName = baseDirInfo.Name;
                string savePathDir = Path.Combine(saveFileDir, baseDirName);

                Directory.CreateDirectory(savePathDir);

                foreach (FileSystemInfo item in baseDirInfo.EnumerateFileSystemInfos())
                {
                    if ((item.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        if (!lstModuleExcludePathesContains(item))
                        {
                            if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                            {
                                DirectoryCopy(item.FullName, Path.Combine(savePathDir, item.Name), copySubDirs: true);
                            }
                            else
                            {
                                File.Copy(item.FullName, Path.Combine(savePathDir, item.Name), true);
                            }
                            Invoke(new Action(() =>
                            {
                                OutputMessage(txtOutput, "Copying " + item.Name);
                            }));
                        }
                    }
                }

                Invoke(new Action(() =>
                {
                    OutputMessage(txtOutput, "Creating Archive......");
                }));
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo();
                process.StartInfo.FileName = "7z.exe";
                process.StartInfo.Arguments = string.Format("{0} \"{1}\" \"{2}\\*\"", "a -tzip -r", txtModSavePath.Text, savePathDir);
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                while (!process.HasExited) { }
                Directory.Delete(savePathDir, recursive: true);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                OutputMessage(txtOutput, "Archive has been saved to " + txtModSavePath.Text);
                OutputMessage(txtOutput, "Finished!");
            }));

            btnStartPack.Enabled = true;
            btnAddModExcludeItem.Enabled = true;
            btnRemoveModExcludeItem.Enabled = false;
            btnBrowseModBaseDir.Enabled = true;
            btnSaveProfile.Enabled = true;
            btnLoadPackProfile.Enabled = true;
            btnBrowseModSavePath.Enabled = true;
            listModExcludeList.Enabled = true;
        }

        private bool lstModuleExcludePathesContains(FileSystemInfo fsi)
        {
            string text = fsi.Name;

            foreach (var item in excludedFileFolders)
            {
                if (item.Name == text)
                {
                    return true;
                }
            }
            return false;
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
            if (!directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            FileInfo[] files = directoryInfo.GetFiles();
            FileInfo[] array = files;
            foreach (FileInfo fileInfo in array)
            {
                string destFileName = Path.Combine(destDirName, fileInfo.Name);
                fileInfo.CopyTo(destFileName, overwrite: false);
            }
            if (copySubDirs)
            {
                DirectoryInfo[] array2 = directories;
                foreach (DirectoryInfo directoryInfo2 in array2)
                {
                    string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
                    DirectoryCopy(directoryInfo2.FullName, destDirName2, copySubDirs);
                }
            }
        }

        private void OutputMessage(RichTextBox richTextBox, string message)
        {
            string line = string.Format("[{0}] {1}", 
                DateTime.Now.ToString("HH:mm:ss"), 
                message + Environment.NewLine);
            richTextBox.Text += line;
        }

        private void btnStartPack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModBaseDir.Text))
            {
                MessageBox.Show("Please select a valid path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!File.Exists(Path.Combine(txtModBaseDir.Text, "module.ini")))
            {
                MessageBox.Show("Please select a valid module path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtModSavePath.Text))
            {
                MessageBox.Show("Please select a valid package output path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            txtOutput.Clear();

            btnStartPack.Enabled = false;
            btnAddModExcludeItem.Enabled = false;
            btnRemoveModExcludeItem.Enabled = false;
            btnBrowseModBaseDir.Enabled = false;
            btnSaveProfile.Enabled = false;
            btnLoadPackProfile.Enabled = false;
            btnBrowseModSavePath.Enabled = false;
            listModExcludeList.Enabled = false;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void btnLoadPackProfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Load Pack Profile";
            dialog.Filter = "Pack Profile|*.mpp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var mbModPackProfile = MBModPackProfile.Load(dialog.FileName);
                loadMBPackProfile(mbModPackProfile);
            }
        }

        private void loadMBPackProfile(MBModPackProfile mbModPackProfile)
        {
            excludedFileFolders.Clear();
            listModExcludeList.Items.Clear();
            btnAddModExcludeItem.Enabled = true;
            btnRemoveModExcludeItem.Enabled = false;

            txtModBaseDir.Text = mbModPackProfile.BaseDir;
            txtModSavePath.Text = mbModPackProfile.SaveDir;
            foreach(var item in mbModPackProfile.ExcludeList)
            {
                FolderFile folderFile = new FolderFile();
                folderFile.Name = item.Name;
                folderFile.Type = item.Type;
                excludedFileFolders.Add(folderFile);

                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = item.Name;
                listViewItem.SubItems.Add(item.Type.ToString());
                listModExcludeList.Items.Add(listViewItem);
            }

            btnSaveProfile.Enabled = true;
            btnStartPack.Enabled = true;
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            frmValueInput valueInputWin = new frmValueInput("Pack Profile",
                "Profile Name:", "Please input a valid profile name!");
            if (valueInputWin.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Save Profile As";
                dialog.Filter = "Profile|*.mpp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = dialog.FileName;

                    MBModPackProfile mbModPackProfile = new MBModPackProfile();
                    mbModPackProfile.Name = valueInputWin.Value;
                    mbModPackProfile.BaseDir = txtModBaseDir.Text.Replace("\\", "/");
                    mbModPackProfile.SaveDir = txtModSavePath.Text.Replace("\\", "/");
                    foreach (var fileFolder in excludedFileFolders)
                    {
                        MBModPackProfileExcludeItem excludeItem = new MBModPackProfileExcludeItem();
                        excludeItem.Name = fileFolder.Name;
                        excludeItem.Type = fileFolder.Type;
                        mbModPackProfile.ExcludeList.Add(excludeItem);
                    }

                    mbModPackProfile.Save(fullPath);
                    MessageBox.Show("Save Finished", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}