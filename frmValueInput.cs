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
    public partial class frmValueInput : Form
    {
        private string title, item, errorMsg;
        public string Value { get { return txtValue.Text; } }

        public frmValueInput(string title, string item, string errorMsg)
        {
            InitializeComponent();
            this.title = title;
            this.item = item;
            this.errorMsg = errorMsg;

            Text = title;
            lbItem.Text = item;
            txtValue.Location = new Point(lbItem.Left + lbItem.Width + 5, txtValue.Location.Y);
            txtValue.Size = new Size(Width - 40 - lbItem.Left - lbItem.Width, txtValue.Size.Height);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValue.Text))
            {
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
