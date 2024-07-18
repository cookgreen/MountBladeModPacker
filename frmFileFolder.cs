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
        private string baseDir;

        public FolderFile SelectedFolderFile { get { return folderFile; } }

        public frmFileFolder(string baseDir)
        {
            InitializeComponent();
            refreshFileFolders(baseDir);
        }

        private void refreshFileFolders(string baseDir)
        {
            DirectoryInfo di = new DirectoryInfo(baseDir);
            foreach(var fileFolderItem in di.GetFileSystemInfos())
            {
                if(fileFolderItem.Attributes == FileAttributes.Directory)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = fileFolderItem.Name;
                    item.SubItems.Add("Folder");
                    item.ImageIndex = 0;
                    listDirectory.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = fileFolderItem.Name;
                    item.SubItems.Add("File");
                    item.ImageIndex = 1;
                    listDirectory.Items.Add(item);
                }
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
