using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRpgLibrary.CharacterClasses;

namespace RpgEditor
{
    public partial class FormEntityData : Form
    {

        #region Field & Properties

        EntityData entityData = null;

        public EntityData EntityData
        {
            get { return entityData; }
            set { entityData = value; }
        }

        #endregion

        #region Constructor Region

        public FormEntityData()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormEntityData_Load);
            this.FormClosing += new FormClosingEventHandler(FormEntityData_FormClosing);

            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Event Region

        void FormEntityData_Load(object sender, EventArgs e)
        {
            if (entityData != null)
            {
                txtName.Text = entityData.EntityName;
                txtStrength.Text = entityData.Strength.ToString();
                txtDexterity.Text = entityData.Dexterity.ToString();
                txtCunning.Text = entityData.Cunning.ToString();
                txtWillpower.Text = entityData.Willpower.ToString();
                txtMagic.Text = entityData.Magic.ToString();
                txtConstitution.Text = entityData.Constitution.ToString();
                txtHealth.Text = entityData.HealthFormula;
                txtStamina.Text = entityData.StaminaFormula;
                txtMana.Text = entityData.MagicFormula;
            }
        }

        void FormEntityData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtHealth.Text) ||
                string.IsNullOrEmpty(txtStamina.Text) || string.IsNullOrEmpty(txtMana.Text))
            {
                MessageBox.Show("Name, Health formula, Stamina foruma and Mana formula must have values");
                return;
            }

            int str = 0;
            int dex = 0;
            int cun = 0;
            int wil = 0;
            int mag = 0;
            int con = 0;

            if(!int.TryParse(txtStrength.Text,out str))
            {
                MessageBox.Show("Strength value invalid");
                return;
            }

            if (!int.TryParse(txtDexterity.Text, out dex))
            {
                MessageBox.Show("Dexterity value invalid");
                return;
            }

            if (!int.TryParse(txtCunning.Text, out cun))
            {
                MessageBox.Show("Cunning value invalid");
                return;
            }

            if (!int.TryParse(txtWillpower.Text, out wil))
            {
                MessageBox.Show("Willpower value invalid");
                return;
            }

            if (!int.TryParse(txtMagic.Text, out mag))
            {
                MessageBox.Show("Magic value invalid");
                return;
            }

            if (!int.TryParse(txtConstitution.Text, out con))
            {
                MessageBox.Show("Constitution value invalid");
                return;
            }

            entityData = new EntityData(
                txtName.Text, str, dex, cun, wil, mag, con, txtHealth.Text, txtStamina.Text, txtMana.Text);

            this.FormClosing -= FormEntityData_FormClosing;

            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            entityData = null;
            this.FormClosing -= FormEntityData_FormClosing;
            this.Close();
        }

        #endregion
    }
}