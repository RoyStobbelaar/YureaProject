using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormKeyDetails : Form
    {
        #region Fields & Properties Region

        KeyData key;

        public KeyData Key
        {
            get { return key; }
            set { key = value; }
        }

        #endregion

        #region Constructor Region

        public FormKeyDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormKeyDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormKeyDetails_Closing);

            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Methods Region

        void FormKeyDetails_Load(object sender, EventArgs e)
        {
            if(key != null)
            {
                txtName.Text = key.Name;
                txtType.Text = key.Type;
            }
        }

        void FormKeyDetails_Closing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("You must enter a name");
                return;
            }

            key = new KeyData();
            key.Name = txtName.Text;
            key.Type = txtType.Text;

            this.FormClosing -= FormKeyDetails_Closing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            key = null;
            this.FormClosing -= FormKeyDetails_Closing;
            this.Close();
        }

        #endregion

        #region Virtual Methods region
        #endregion
    }
}
