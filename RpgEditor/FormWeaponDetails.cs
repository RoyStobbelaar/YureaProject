using RpgLibrary;
using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRpgLibrary.EffectClasses;
using XRpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormWeaponDetails : Form
    {
        #region Fields & Properties

        WeaponData weapon = null;

        public WeaponData Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        #endregion

        #region Constructor Region

        public FormWeaponDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormWeaponDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormWeaponDetails_Closing);

            btnAllowed.Click += new EventHandler(btnAllowed_Click);
            btnRemoveAllowed.Click += new EventHandler(btnRemoveAllowed_Click);
            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Event Methods

        private void FormWeaponDetails_Closing(object sender, FormClosingEventArgs e)
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

        private void FormWeaponDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);

            foreach (Hands location in Enum.GetValues(typeof(Hands)))
                txtHands.Items.Add(location);
            foreach (DieType die in Enum.GetValues(typeof(DieType)))
                txtDieType.Items.Add(die);

            txtHands.SelectedIndex = 0;
            txtDieType.SelectedIndex = 0;

            if(weapon != null)
            {
                txtName.Text = weapon.Name;
                txtType.Text = weapon.Type;
                txtPrice.Text = weapon.Price.ToString();
                txtWeight.Value = (decimal)weapon.Weight;
                txtHands.SelectedIndex = (int)weapon.NumberHands;
                txtAttackValue.Text = weapon.AttackValue.ToString();
                txtAttackModifier.Text = weapon.AttackModifier.ToString();

                for(int i = 0; i < txtDieType.Items.Count; i++)
                {
                    if(txtDieType.Items[i].ToString() == weapon.DamageEffectData.DieType.ToString())
                    {
                        txtDieType.SelectedIndex = i;
                        txtDieType.SelectedValue = txtDieType.Items[i];
                        break;
                    }
                }

                nudNumberOfDice.Value = weapon.DamageEffectData.NumberOfDice;
                txtDamageModifier.Text = weapon.DamageEffectData.Modifier.ToString();
               
                foreach(string s in weapon.AllowableClasses)
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
            int attVal = 0;
            int attMod = 0;
            int dmgMod = 0;

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

            if(!int.TryParse(txtAttackValue.Text, out attVal))
            {
                MessageBox.Show("You must enter attack value");
                return;
            }

            if(!int.TryParse(txtAttackModifier.Text, out attMod))
            {
                MessageBox.Show("You must enter attack modifier");
                return;
            }

            if(!int.TryParse(txtDamageModifier.Text,out dmgMod))
            {
                MessageBox.Show("you must enter damage modifier");
                return;
            }

            List<string> allowedClasses = new List<string>();

            foreach (object o in lbAllowedClasses.Items)
                allowedClasses.Add(o.ToString());

            weapon = new WeaponData();
            weapon.Name = txtName.Text;
            weapon.Type = txtType.Text;
            weapon.Price = price;
            weapon.Weight = weight;
            weapon.AttackValue = attVal;
            weapon.AttackModifier = attMod;
            weapon.AllowableClasses = allowedClasses.ToArray();

            weapon.DamageEffectData.Name = txtName.Text;
            weapon.DamageEffectData.AttackType = AttackType.Health;
            weapon.DamageEffectData.DamageType = DamageType.Weapon;

            weapon.DamageEffectData.DieType = (DieType)Enum.Parse(typeof(DieType), txtDieType.Items[txtDieType.SelectedIndex].ToString());

            weapon.DamageEffectData.NumberOfDice = (int)nudNumberOfDice.Value;
            weapon.DamageEffectData.Modifier = dmgMod;

            this.FormClosing -= FormWeaponDetails_Closing;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            weapon = null;
            this.FormClosing -= FormWeaponDetails_Closing;
            this.Close();
        }
        #endregion
    }
}