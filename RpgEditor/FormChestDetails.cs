using RpgLibrary.ItemClasses;
using RpgLibrary.SkillClasses;
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
    public partial class FormChestDetails : Form
    {
        #region Fields & Properties Region

        ChestData chest;

        public ChestData Chest
        {
            get { return chest; }
            set { chest = value; }
        }

        #endregion

        #region Constructor Region

        public FormChestDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormChestDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormChestDetails_Closing);

            foreach(string s in Enum.GetNames(typeof(DifficultyLevel)))
            {
                cbDifficulty.Items.Add(s);
            }

            cbDifficulty.SelectedIndex = 0;

            cbLocked.CheckedChanged += new EventHandler(cbLocked_CheckedChanged);
            cbTrapped.CheckedChanged += new EventHandler(cbTrapped_CheckedChanged);

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnRemove.Click += new EventHandler(btnRemove_Click);

            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            cbLocked_CheckedChanged(null, null);
            cbTrapped_CheckedChanged(null, null);

        }

        #endregion

        #region Methods Region

        void FormChestDetails_Load(object sender, EventArgs e)
        {
            if (chest != null)
            {
                txtName.Text = chest.Name;
                cbLocked.Checked = chest.IsLocked;
                txtKeyName.Text = chest.KeyName;
                txtKeyType.Text = chest.KeyType;
                txtKeysNeeded.Value = (decimal)chest.KeysRequired;

                txtKeyName.Enabled = chest.IsLocked;
                txtKeyType.Enabled = chest.IsLocked;
                txtKeysNeeded.Enabled = chest.IsLocked;

                cbTrapped.Checked = chest.IsTrapped;
                txtTrapName.Text = chest.TrapName;

                txtTrapName.Enabled = chest.IsTrapped;

                txtMinGold.Value = (decimal)chest.MinGold;
                txtMaxGold.Value = (decimal)chest.MaxGold;
            }
        }

        void FormChestDetails_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        void cbLocked_CheckedChanged(object sender, EventArgs e)
        {
            cbDifficulty.Enabled = cbLocked.Checked;
            txtKeyName.Enabled = cbLocked.Checked;
            txtKeyType.Enabled = cbLocked.Checked;
            txtKeysNeeded.Enabled = cbLocked.Checked;
        }

        void cbTrapped_CheckedChanged(object sender, EventArgs e)
        {
            txtTrapName.Enabled = cbTrapped.Checked;
        }

        void btnAdd_Click(object sender, EventArgs e)
        {

        }

        void btnRemove_Click(object sender, EventArgs e)
        {

        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("You must enter a name for this chest");
                return;
            }

            if (cbTrapped.Checked && string.IsNullOrEmpty(txtTrapName.Text))
            {
                MessageBox.Show("You must enter a name for this trap");
                return;
            }

            if (txtMaxGold.Value < txtMinGold.Value)
            {
                MessageBox.Show("Max gold should be higher then min gold");
                return;
            }

            ChestData data = new ChestData();

            data.Name = txtName.Text;
            data.IsLocked = cbLocked.Checked;

            if (cbLocked.Checked)
            {
                data.DifficultyLevel = (DifficultyLevel)cbDifficulty.SelectedIndex;
                data.KeyName = txtKeyName.Text;
                data.KeyType = txtKeyType.Text;
                data.KeysRequired = (int)txtKeysNeeded.Value;
            }

            data.IsTrapped = cbTrapped.Checked;

            if (cbTrapped.Checked)
            {
                data.TrapName = txtTrapName.Text;
            }

            data.MinGold = (int)txtMinGold.Value;
            data.MaxGold = (int)txtMaxGold.Value;

            chest = data;
            this.FormClosing -= FormChestDetails_Closing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            chest = null;
            this.FormClosing -= FormChestDetails_Closing;
            this.Close();
        }

        #endregion


        #region Virtual Methods region
        #endregion
    }
}
