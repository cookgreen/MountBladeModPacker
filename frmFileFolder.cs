using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MountBladeModPacker
{
    public partial class frmFileFolder : Form
    {
        private FolderFile folderFile;
        private List<string> folders;
        private List<string> files;
        private string currentDir;

        public FolderFile SelectedFolderFile { get { return folderFile; } }

        public frmFileFolder(string currentDir)
        {
            InitializeComponent();
            folders = new List<string>();
            files = new List<string>();
            refreshFileFolders(currentDir);
        }

        private void refreshFileFolders(string currentDir)
        {
            this.currentDir = currentDir;
            folders.Clear();
            files.Clear();

            DirectoryInfo di = new DirectoryInfo(currentDir);
            foreach(var fileFolderItem in di.GetFileSystemInfos())
            {
                if ((fileFolderItem.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    continue;

                if ((fileFolderItem.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    folders.Add(fileFolderItem.Name);
                }
                else
                {
                    files.Add(fileFolderItem.Name);
                }

            }

            folders.Sort();
            files.Sort();
            
            foreach(var folder in folders)
            {
                ListViewItem item = new ListViewItem();
                item.Text = folder;
                item.SubItems.Add("Folder");
                item.ImageIndex = 0;
                listDirectory.Items.Add(item);
            }

            foreach (var file in files)
            {
                ListViewItem item = new ListViewItem();
                item.Text = file;
                item.SubItems.Add("File");
                item.ImageIndex = 1;
                listDirectory.Items.Add(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            var item = listDirectory.SelectedItems[0];
            FolderFile folderFile = new FolderFile();
            folderFile.Name = item.Text;
            if (item.SubItems[1].Text == "Folder")
                folderFile.Type = FolderFileType.Folder;
            else if(item.SubItems[1].Text == "File")
                folderFile.Type = FolderFileType.File;
            this.folderFile = folderFile;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
