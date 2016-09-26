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
    public partial class FormArmor : FormDetails
    {
        #region Constructor Region

        public FormArmor()
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
            using (FormArmorDetails formArmorDetails = new FormArmorDetails())
            {
                formArmorDetails.ShowDialog();
                if(formArmorDetails.Armor != null)
                {
                    AddArmor(formArmorDetails.Armor);
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

                ArmorData data = itemDataManager.ArmorData[entity];
                ArmorData newData = null;

                using (FormArmorDetails formArmorData = new FormArmorDetails())
                {
                    formArmorData.Armor = data;
                    formArmorData.ShowDialog();

                    if (formArmorData.Armor == null)
                        return;

                    if(formArmorData.Armor.Name == entity)
                    {
                        itemDataManager.ArmorData[entity] = formArmorData.Armor;
                        FillListBox();
                        return;
                    }

                    newData = formArmorData.Armor;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add new entry?", "New entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (itemDataManager.ArmorData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify entry");
                    return;
                }

                lbDetails.Items.Add(newData);
                itemDataManager.ArmorData.Add(newData.Name, newData);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lbDetails.SelectedItem!= null)
            {
                string detail = (string)lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show("Are you sure you want to delete?","Delete",MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    itemDataManager.ArmorData.Remove(entity);

                    if (File.Exists(FormMain.ItemPath + @"\Armor\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\Armor\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Methods Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemDataManager.ArmorData.Keys)
                lbDetails.Items.Add(FormDetails.ItemDataManager.ArmorData[s]);
        }

        private void AddArmor(ArmorData armorData)
        {
            if (FormDetails.itemDataManager.ArmorData.ContainsKey(armorData.Name))
            {
                DialogResult result = MessageBox.Show(armorData.Name + " already exists. Overwrite it?","Existing armor",MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemDataManager.ArmorData[armorData.Name] = armorData;
                FillListBox();
                return;
            }

            itemDataManager.ArmorData.Add(armorData.Name, armorData);
            lbDetails.Items.Add(armorData);
        }

        #endregion
    }
}
