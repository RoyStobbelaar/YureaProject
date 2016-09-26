using RpgLibrary.ItemClasses;
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
    public partial class FormShield : FormDetails
    {
        #region Constructor Region

        public FormShield()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        #endregion

        #region Methods Region

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormShieldDetails formShieldDetails = new FormShieldDetails())
            {
                formShieldDetails.ShowDialog();

                if (formShieldDetails.Shield != null)
                {
                    AddShield(formShieldDetails.Shield);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                ShieldData data = itemDataManager.ShieldData[entity];
                ShieldData newData = null;

                using (FormShieldDetails formShieldData = new FormShieldDetails())
                {
                    formShieldData.Shield = data;
                    formShieldData.ShowDialog();

                    if (formShieldData.Shield == null)
                        return;

                    if(formShieldData.Shield.Name == entity)
                    {
                        itemDataManager.ShieldData[entity] = formShieldData.Shield;
                        FillListBox();
                        return;
                    }

                    newData = formShieldData.Shield;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (itemDataManager.ShieldData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. use edit to modify entry");
                    return;
                }

                lbDetails.Items.Add(newData);
                itemDataManager.ShieldData.Add(newData.Name, newData);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lbDetails.SelectedItem!=null)
            {
                string detail = (string)lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    itemDataManager.ShieldData.Remove(entity);

                    if (File.Exists(FormMain.ItemPath + @"\Shield\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\Shield\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Methods Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemDataManager.ShieldData.Keys)
                lbDetails.Items.Add(FormDetails.ItemDataManager.ShieldData[s]);
        }

        private void AddShield(ShieldData shieldData)
        {
            if (FormDetails.itemDataManager.ShieldData.ContainsKey(shieldData.Name))
            {
                DialogResult result = MessageBox.Show(shieldData.Name + "already exists. Overwrite it?", "Existing shield", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemDataManager.ShieldData[shieldData.Name] = shieldData;
                FillListBox();
                return;
            }

            itemDataManager.ShieldData[shieldData.Name] = shieldData;
            lbDetails.Items.Add(shieldData);
        }

        #endregion
    }
}
