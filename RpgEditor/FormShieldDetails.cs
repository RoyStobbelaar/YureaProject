using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormShieldDetails : Form
    {

        #region Fields & Properties

        ShieldData shield=null;

        public ShieldData Shield
        {
            get { return shield; }
            set { shield = value; }
        }

        #endregion

        #region Constructor Region

        public FormShieldDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormShieldDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormShieldDetails_Closing);

            btnAllowed.Click += new EventHandler(btnAllowed_Click);
            btnRemoveAllowed.Click += new EventHandler(btnRemoveAllowed_Click);
            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Event Methods

        private void FormShieldDetails_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void btnAllowed_Click(object sender, EventArgs e)
        {
            if (lbClasses.SelectedItem != null)
            {
                lbAllowedClasses.Items.Add(lbClasses.SelectedItem);
                lbClasses.Items.RemoveAt(lbClasses.SelectedIndex);
            }
        }

        private void btnRemoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbAllowedClasses.SelectedItem != null)
            {
                lbClasses.Items.Add(lbAllowedClasses.SelectedItem);
                lbAllowedClasses.Items.RemoveAt(lbAllowedClasses.SelectedIndex);
            }
        }

        private void FormShieldDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);

            if (shield != null)
            {
                txtName.Text = shield.Name;
                txtType.Text = shield.Type;
                txtPrice.Text = shield.Price.ToString();
                txtWeight.Value = (decimal)shield.Weight;
                txtDefenseValue.Text = shield.DefenseValue.ToString();
                txtDefenseModifier.Text = shield.DefenseModifier.ToString();

                foreach(string s in shield.AllowableClasses)
                {
                    if (lbClasses.Items.Contains(s))
                        lbClasses.Items.Remove(s);

                    lbAllowedClasses.Items.Add(s);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int price = 0;
            float weight = 0f;
            int defVal = 0;
            int defMod = 0;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("You must enter a name");
                return;
            }

            if(!int.TryParse(txtPrice.Text,out price))
            {
                MessageBox.Show("You must enter a price");
                return;
            }

            weight = (float)txtWeight.Value;

            if(!int.TryParse(txtDefenseValue.Text,out defVal))
            {
                MessageBox.Show("You must enter a defensive value");
                return;
            }

            if(!int.TryParse(txtDefenseModifier.Text, out defMod))
            {
                MessageBox.Show("You must enter a defensive modifier");
                return;
            }

            List<string> allowedClasses = new List<string>();

            foreach (object o in lbAllowedClasses.Items)
                allowedClasses.Add(o.ToString());

            shield = new ShieldData();
            shield.Name = txtName.Text;
            shield.Type = txtType.Text;
            shield.Price = price;
            shield.Weight = weight;
            shield.DefenseValue = defVal;
            shield.DefenseModifier = defMod;
            shield.AllowableClasses = allowedClasses.ToArray();

            this.FormClosing -= FormShieldDetails_Closing;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            shield = null;
            this.FormClosing -= FormShieldDetails_Closing;
            this.Close();
        }

        #endregion
    }
}