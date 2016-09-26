using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRpgLibrary.CharacterClasses;

namespace RpgEditor
{
    public partial class FormClasses : FormDetails
    {
        #region Fields & Properties
        #endregion

        #region Constructor Region

        public FormClasses()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);

        }

        #endregion

        #region Event Methods

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormEntityData formEntityData = new FormEntityData())
            {
                formEntityData.ShowDialog();

                if(formEntityData.EntityData != null)
                {
                    AddEntity(formEntityData.EntityData);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();
                EntityData data = entityDataManager.EntityData[entity];
                EntityData newData = null;

                using (FormEntityData formEntityData = new FormEntityData())
                {
                    formEntityData.EntityData = data;
                    formEntityData.ShowDialog();

                    if (formEntityData.EntityData == null)
                        return;

                    if(formEntityData.EntityData.EntityName == entity)
                    {
                        entityDataManager.EntityData[entity] = formEntityData.EntityData;
                        FillListBox();
                        return;
                    }

                    newData = formEntityData.EntityData;
                }

                DialogResult result = MessageBox.Show(newData.EntityName + " has changed. Do you want to add a new entry?", "New Entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (entityDataManager.EntityData.ContainsKey(newData.EntityName))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify");
                    return;
                }

                lbDetails.Items.Add(newData);
                entityDataManager.EntityData.Add(newData.EntityName, newData);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + entity + "?", "Delete", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    entityDataManager.EntityData.Remove(entity);

                    if (File.Exists(FormMain.ClassPath + @"\" + entity + ".xml"))
                        File.Delete(FormMain.ClassPath + @"\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Methods Region

        private void AddEntity(EntityData entityData)
        {
            if (FormDetails.EntityDataManager.EntityData.ContainsKey(entityData.EntityName))
            {
                DialogResult result = MessageBox.Show(
                    entityData.EntityName + " already exists. Do you want to overwrite?",
                    "Existing character class",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                FormDetails.EntityDataManager.EntityData[entityData.EntityName] = entityData;

                FillListBox();
                return;
            }

            lbDetails.Items.Add(entityData.ToString());

            FormDetails.EntityDataManager.EntityData.Add(entityData.EntityName, entityData);
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbDetails.Items.Add(FormDetails.EntityDataManager.EntityData[s]);
        }

        #endregion
    }
}