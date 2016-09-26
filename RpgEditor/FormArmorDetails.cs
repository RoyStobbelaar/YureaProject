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
    public partial class FormArmorDetails : Form
    {

        #region Fields & Properties

        ArmorData armor = null;

        public ArmorData Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        #endregion

        #region Constructor Region

        public FormArmorDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormArmorDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormArmorDetails_FormClosing);

            btnAllowed.Click += new EventHandler(btnAllowed_Click);
            btnRemoveAllowed.Click += new EventHandler(btnRemoveAllowed_Click);
            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Event Methods

        private void FormArmorDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void btnAllowed_Click(object sender, EventArgs e)
        {
            if(lbClasses.SelectedItem != null)
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

        private void FormArmorDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);

            foreach (ArmorLocation location in Enum.GetValues(typeof(ArmorLocation)))
                txtArmorLocation.Items.Add(location);

            txtArmorLocation.SelectedIndex = 0;

            if (armor != null)
            {
                txtName.Text = armor.Name;
                txtType.Text = armor.Type;
                txtPrice.Text = armor.Price.ToString();
                txtWeight.Value = (decimal)armor.Weight;
                txtArmorLocation.SelectedIndex = (int)armor.ArmorLocation;
                txtDefenseValue.Text = armor.DefenseValue.ToString();
                txtDefenseModifier.Text = armor.DefenseModifier.ToString();

                foreach (string s in armor.AllowableClasses)
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

            if(!int.TryParse(txtDefenseModifier.Text,out defMod))
            {
                MessageBox.Show("You must enter a defensive modifier");
                return;
            }

            List<string> allowedClasses = new List<string>();
            foreach (object o in lbAllowedClasses.Items)
                allowedClasses.Add(o.ToString());

            armor = new ArmorData();
            armor.Name = txtName.Text;
            armor.Type = txtType.Text;
            armor.Price = price;
            armor.Weight = weight;
            armor.ArmorLocation = (ArmorLocation)txtArmorLocation.SelectedIndex;
            armor.DefenseValue = defVal;
            armor.DefenseModifier = defMod;
            armor.AllowableClasses = allowedClasses.ToArray();

            this.FormClosing -= FormArmorDetails_FormClosing;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            armor = null;
            this.FormClosing -= FormArmorDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}