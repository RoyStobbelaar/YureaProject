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
    public partial class FormSkillsDetail : Form
    {

        #region Fields & Properties Region

        SkillData skill;

        public SkillData Skill
        {
            get { return skill; }
            set { skill = value; }
        }

        #endregion
        #region Constructor Region

        public FormSkillsDetail()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormSkillsDetail_Load);
            this.FormClosing += new FormClosingEventHandler(FormSkillsDetail_FormClosing);

            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion
        #region Methods Region

        void FormSkillsDetail_Load(object sender, EventArgs e)
        {
            if(skill != null)
            {
                txtName.Text = Skill.Name;
                switch (Skill.PrimaryAttribute.ToLower())
                {
                    case "strength":
                        rbStrength.Checked = true;
                        break;
                    case "dexterity":
                        rbDexterity.Checked = true;
                        break;
                    case "cunning":
                        rbCunning.Checked = true;
                        break;
                    case "willpower":
                        rbWillpower.Checked = true;
                        break;
                    case "magic":
                        rbMagic.Checked = true;
                        break;
                    case "constitution":
                        rbConstitution.Checked = true;
                        break;
                }

                foreach(string s in Skill.ClassModifiers.Keys)
                {
                    string data = s + ", " + Skill.ClassModifiers[s].ToString();
                    lbModifiers.Items.Add(data);
                }
            }
        }

        void FormSkillsDetail_FormClosing(object sender, FormClosingEventArgs e)
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
                MessageBox.Show("You must provide a name for the skill");
                return;
            }

            SkillData newSkill = new SkillData();

            newSkill.Name = txtName.Text;

            if (rbStrength.Checked)
                newSkill.PrimaryAttribute = "Strength";
            else if (rbDexterity.Checked)
                newSkill.PrimaryAttribute = "Dexterity";
            else if (rbCunning.Checked)
                newSkill.PrimaryAttribute = "Cunning";
            else if (rbWillpower.Checked)
                newSkill.PrimaryAttribute = "Willpower";
            else if (rbMagic.Checked)
                newSkill.PrimaryAttribute = "Magic";
            else if (rbConstitution.Checked)
                newSkill.PrimaryAttribute = "Constitution";

            skill = newSkill;
            this.FormClosing -= FormSkillsDetail_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            skill = null;
            this.FormClosing -= FormSkillsDetail_FormClosing;
            this.Close();
        }

        #endregion
        #region Virtual Methods region
        #endregion
    }
}
