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
    public partial class FormChest : FormDetails
    {

        #region Fields & Properties Region
        #endregion

        #region Constructor Region

        public FormChest()
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
            using (FormChestDetails formChestDetails = new FormChestDetails())
            {
                formChestDetails.ShowDialog();

                if(formChestDetails.Chest != null)
                {
                    AddChest(formChestDetails.Chest);
                }
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if(lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                ChestData data = itemDataManager.ChestData[entity];
                ChestData newData = null;

                using(FormChestDetails formChestData = new FormChestDetails())
                {
                    formChestData.Chest = data;
                    formChestData.ShowDialog();

                    if (formChestData.Chest == null)
                        return;

                    if(formChestData.Chest.Name == entity)
                    {
                        itemDataManager.ChestData[entity] = formChestData.Chest;
                        FillListBox();
                        return;
                    }

                    newData = formChestData.Chest;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (itemDataManager.ChestData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify the entry");
                    return;
                }

                lbDetails.Items.Add(newData);
                itemDataManager.ChestData.Add(newData.Name, newData);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if(lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + entity + "?","Delete",MessageBoxButtons.YesNo);

                if(result  == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    itemDataManager.ChestData.Remove(entity);

                    if (File.Exists(FormMain.ItemPath + @"\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\" + entity + ".xml");
                }
            }
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.itemDataManager.ChestData.Keys)
                lbDetails.Items.Add(FormDetails.itemDataManager.ChestData[s]);
        }

        private void AddChest(ChestData chestData)
        {
            if (FormDetails.itemDataManager.ChestData.ContainsKey(chestData.Name))
            {
                DialogResult result = MessageBox.Show(chestData.Name + " already exists. Overwrite it?", "Existing chest",MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemDataManager.ChestData[chestData.Name] = chestData;
                FillListBox();
                return;
            }

            itemDataManager.ChestData.Add(chestData.Name, chestData);
            lbDetails.Items.Add(chestData);
        }

        #endregion

        #region Virtual Methods region
        #endregion
    }
}
