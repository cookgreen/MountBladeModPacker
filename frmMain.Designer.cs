namespace MountBladeModulePacker
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbModBaseDir = new System.Windows.Forms.Label();
            this.txtModBaseDir = new System.Windows.Forms.TextBox();
            this.lbModExcludeList = new System.Windows.Forms.Label();
            this.btnBrowseModBaseDir = new System.Windows.Forms.Button();
            this.listModExcludeList = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.btnAddModExcludeItem = new System.Windows.Forms.Button();
            this.btnRemoveModExcludeItem = new System.Windows.Forms.Button();
            this.lbModSavePath = new System.Windows.Forms.Label();
            this.btnBrowseModSavePath = new System.Windows.Forms.Button();
            this.txtModSavePath = new System.Windows.Forms.TextBox();
            this.groupOutput = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnStartPack = new System.Windows.Forms.Button();
            this.btnLoadPackProfile = new System.Windows.Forms.Button();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.groupOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbModBaseDir
            // 
            this.lbModBaseDir.AutoSize = true;
            this.lbModBaseDir.Location = new System.Drawing.Point(12, 19);
            this.lbModBaseDir.Name = "lbModBaseDir";
            this.lbModBaseDir.Size = new System.Drawing.Size(110, 20);
            this.lbModBaseDir.TabIndex = 0;
            this.lbModBaseDir.Text = "Mod Base Dir:";
            // 
            // txtModBaseDir
            // 
            this.txtModBaseDir.Location = new System.Drawing.Point(154, 16);
            this.txtModBaseDir.Name = "txtModBaseDir";
            this.txtModBaseDir.ReadOnly = true;
            this.txtModBaseDir.Size = new System.Drawing.Size(387, 27);
            this.txtModBaseDir.TabIndex = 1;
            // 
            // lbModExcludeList
            // 
            this.lbModExcludeList.AutoSize = true;
            this.lbModExcludeList.Location = new System.Drawing.Point(12, 61);
            this.lbModExcludeList.Name = "lbModExcludeList";
            this.lbModExcludeList.Size = new System.Drawing.Size(137, 20);
            this.lbModExcludeList.TabIndex = 2;
            this.lbModExcludeList.Text = "Mod Exclude List:";
            // 
            // btnBrowseModBaseDir
            // 
            this.btnBrowseModBaseDir.Location = new System.Drawing.Point(547, 9);
            this.btnBrowseModBaseDir.Name = "btnBrowseModBaseDir";
            this.btnBrowseModBaseDir.Size = new System.Drawing.Size(57, 41);
            this.btnBrowseModBaseDir.TabIndex = 3;
            this.btnBrowseModBaseDir.Text = "...";
            this.btnBrowseModBaseDir.UseVisualStyleBackColor = true;
            this.btnBrowseModBaseDir.Click += new System.EventHandler(this.btnBrowseModBaseDir_Click);
            // 
            // listModExcludeList
            // 
            this.listModExcludeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType});
            this.listModExcludeList.FullRowSelect = true;
            this.listModExcludeList.GridLines = true;
            this.listModExcludeList.Location = new System.Drawing.Point(155, 61);
            this.listModExcludeList.Name = "listModExcludeList";
            this.listModExcludeList.Size = new System.Drawing.Size(386, 209);
            this.listModExcludeList.TabIndex = 4;
            this.listModExcludeList.UseCompatibleStateImageBehavior = false;
            this.listModExcludeList.View = System.Windows.Forms.View.Details;
            this.listModExcludeList.SelectedIndexChanged += new System.EventHandler(this.listModExcludeList_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 180;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 190;
            // 
            // btnAddModExcludeItem
            // 
            this.btnAddModExcludeItem.Enabled = false;
            this.btnAddModExcludeItem.Location = new System.Drawing.Point(547, 61);
            this.btnAddModExcludeItem.Name = "btnAddModExcludeItem";
            this.btnAddModExcludeItem.Size = new System.Drawing.Size(57, 57);
            this.btnAddModExcludeItem.TabIndex = 5;
            this.btnAddModExcludeItem.Text = "+";
            this.btnAddModExcludeItem.UseVisualStyleBackColor = true;
            this.btnAddModExcludeItem.Click += new System.EventHandler(this.btnAddModExcludeItem_Click);
            // 
            // btnRemoveModExcludeItem
            // 
            this.btnRemoveModExcludeItem.Enabled = false;
            this.btnRemoveModExcludeItem.Location = new System.Drawing.Point(547, 125);
            this.btnRemoveModExcludeItem.Name = "btnRemoveModExcludeItem";
            this.btnRemoveModExcludeItem.Size = new System.Drawing.Size(57, 57);
            this.btnRemoveModExcludeItem.TabIndex = 6;
            this.btnRemoveModExcludeItem.Text = "-";
            this.btnRemoveModExcludeItem.UseVisualStyleBackColor = true;
            this.btnRemoveModExcludeItem.Click += new System.EventHandler(this.btnRemoveModExcludeItem_Click);
            // 
            // lbModSavePath
            // 
            this.lbModSavePath.AutoSize = true;
            this.lbModSavePath.Location = new System.Drawing.Point(12, 285);
            this.lbModSavePath.Name = "lbModSavePath";
            this.lbModSavePath.Size = new System.Drawing.Size(122, 20);
            this.lbModSavePath.TabIndex = 7;
            this.lbModSavePath.Text = "Mod Save Path:";
            // 
            // btnBrowseModSavePath
            // 
            this.btnBrowseModSavePath.Location = new System.Drawing.Point(548, 275);
            this.btnBrowseModSavePath.Name = "btnBrowseModSavePath";
            this.btnBrowseModSavePath.Size = new System.Drawing.Size(57, 41);
            this.btnBrowseModSavePath.TabIndex = 9;
            this.btnBrowseModSavePath.Text = "...";
            this.btnBrowseModSavePath.UseVisualStyleBackColor = true;
            this.btnBrowseModSavePath.Click += new System.EventHandler(this.btnBrowseModSavePath_Click);
            // 
            // txtModSavePath
            // 
            this.txtModSavePath.Location = new System.Drawing.Point(155, 282);
            this.txtModSavePath.Name = "txtModSavePath";
            this.txtModSavePath.ReadOnly = true;
            this.txtModSavePath.Size = new System.Drawing.Size(387, 27);
            this.txtModSavePath.TabIndex = 8;
            // 
            // groupOutput
            // 
            this.groupOutput.Controls.Add(this.txtOutput);
            this.groupOutput.Location = new System.Drawing.Point(12, 329);
            this.groupOutput.Name = "groupOutput";
            this.groupOutput.Size = new System.Drawing.Size(592, 303);
            this.groupOutput.TabIndex = 10;
            this.groupOutput.TabStop = false;
            this.groupOutput.Text = "Output";
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 23);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(586, 277);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            // 
            // btnStartPack
            // 
            this.btnStartPack.Enabled = false;
            this.btnStartPack.Location = new System.Drawing.Point(434, 638);
            this.btnStartPack.Name = "btnStartPack";
            this.btnStartPack.Size = new System.Drawing.Size(167, 60);
            this.btnStartPack.TabIndex = 11;
            this.btnStartPack.Text = "START";
            this.btnStartPack.UseVisualStyleBackColor = true;
            this.btnStartPack.Click += new System.EventHandler(this.btnStartPack_Click);
            // 
            // btnLoadPackProfile
            // 
            this.btnLoadPackProfile.Location = new System.Drawing.Point(15, 638);
            this.btnLoadPackProfile.Name = "btnLoadPackProfile";
            this.btnLoadPackProfile.Size = new System.Drawing.Size(167, 60);
            this.btnLoadPackProfile.TabIndex = 12;
            this.btnLoadPackProfile.Text = "Load Profile";
            this.btnLoadPackProfile.UseVisualStyleBackColor = true;
            this.btnLoadPackProfile.Click += new System.EventHandler(this.btnLoadPackProfile_Click);
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.Enabled = false;
            this.btnSaveProfile.Location = new System.Drawing.Point(188, 638);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(167, 60);
            this.btnSaveProfile.TabIndex = 13;
            this.btnSaveProfile.Text = "Save Profile As";
            this.btnSaveProfile.UseVisualStyleBackColor = true;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 710);
            this.Controls.Add(this.btnSaveProfile);
            this.Controls.Add(this.btnLoadPackProfile);
            this.Controls.Add(this.btnStartPack);
            this.Controls.Add(this.groupOutput);
            this.Controls.Add(this.btnBrowseModSavePath);
            this.Controls.Add(this.txtModSavePath);
            this.Controls.Add(this.lbModSavePath);
            this.Controls.Add(this.btnRemoveModExcludeItem);
            this.Controls.Add(this.btnAddModExcludeItem);
            this.Controls.Add(this.listModExcludeList);
            this.Controls.Add(this.btnBrowseModBaseDir);
            this.Controls.Add(this.lbModExcludeList);
            this.Controls.Add(this.txtModBaseDir);
            this.Controls.Add(this.lbModBaseDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mount&Blade Mod Packer";
            this.groupOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbModBaseDir;
        private TextBox txtModBaseDir;
        private Label lbModExcludeList;
        private Button btnBrowseModBaseDir;
        private ListView listModExcludeList;
        private Button btnAddModExcludeItem;
        private Button btnRemoveModExcludeItem;
        private ColumnHeader colName;
        private ColumnHeader colType;
        private Label lbModSavePath;
        private Button btnBrowseModSavePath;
        private TextBox txtModSavePath;
        private GroupBox groupOutput;
        private RichTextBox txtOutput;
        private Button btnStartPack;
        private Button btnLoadPackProfile;
        private Button btnSaveProfile;
    }
}