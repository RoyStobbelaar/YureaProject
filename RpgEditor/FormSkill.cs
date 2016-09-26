using RpgLibrary.SkillClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormSkill : FormDetails
    {

        #region Fields & Properties Region



        #endregion
        #region Constructor Region


        public FormSkill()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        #endregion
        #region Methods Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using(FormSkillsDetail formSkillsDetails = new FormSkillsDetail())
            {
                formSkillsDetails.ShowDialog();

                if(formSkillsDetails.Skill != null)
                {
                    AddSkill(formSkillsDetails.Skill);
                }
            }
        }

        void btnEdit_Click(object sender,EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                SkillData data = skillDataManager.SkillData[entity];
                SkillData newData = null;

                using(FormSkillsDetail formSkillsDetail = new FormSkillsDetail())
                {
                    formSkillsDetail.Skill = data;
                    formSkillsDetail.ShowDialog();

                    if (formSkillsDetail.Skill == null)
                        return;

                    if(formSkillsDetail.Skill.Name == entity)
                    {
                        skillDataManager.SkillData[entity] = formSkillsDetail.Skill;
                        FillListBox();
                        return;
                    }

                    newData = formSkillsDetail.Skill;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?","New entry",MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (skillDataManager.SkillData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify entry");
                    return;
                }

                lbDetails.Items.Add(newData);
                skillDataManager.SkillData.Add(newData.Name, newData);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if(lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + entity + "?", "Delete",MessageBoxButtons.YesNo );

                if(result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    skillDataManager.SkillData.Remove(entity);

                    if (File.Exists(FormMain.SkillPath + @"\" + entity + ".xml"))
                        File.Delete(FormMain.SkillPath + @"\" + entity + ".xml");
                }
            }
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.skillDataManager.SkillData.Keys)
                lbDetails.Items.Add(FormDetails.skillDataManager.SkillData[s]);
        }

        private void AddSkill(SkillData skillData)
        {
            if (FormDetails.SkillDataManager.SkillData.ContainsKey(skillData.Name))
            {
                DialogResult result = MessageBox.Show(skillData.Name + " already exists. Overwrite it?","Existing skill",MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                skillDataManager.SkillData[skillData.Name] = skillData;
                FillListBox();
                return;
            }

            skillDataManager.SkillData.Add(skillData.Name, skillData);
            lbDetails.Items.Add(skillData);
        }

        #endregion
        #region Virtual Methods region
        #endregion

    }
}
