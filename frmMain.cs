using MountBladeModPacker;

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
                string folderPath = dialog.SelectedPath;
                if(File.Exists(Path.Combine(folderPath, "module.ini")))
                {
                    //Valid folder
                    txtModBaseDir.Text = folderPath;
                    btnAddModExcludeItem.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid Mount&Blade Mod Path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Invalid folder, clear the path
                    txtModBaseDir.Text = null;
                    btnAddModExcludeItem.Enabled = false;
                }
            }
        }

        private void btnBrowseModSavePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Archive File|*.7z";
            if(dialog.ShowDialog() == DialogResult.OK ) 
            {
                txtModSavePath.Text = dialog.FileName;
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
                    excludedFileFolders.Add(fileFolder);
                    
                    ListViewItem item = new ListViewItem();
                    item.Text = fileFolder.Name;
                    item.SubItems.Add(fileFolder.Type.ToString());
                    listModExcludeList.Items.Add(item);
                }
            }
        }

        private void btnRemoveModExcludeItem_Click(object sender, EventArgs e)
        {

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

        private void btnStartPack_Click(object sender, EventArgs e)
        {

        }
    }
}