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
    public partial class FormKey : FormDetails
    {

        #region Fields & Properties Region
        #endregion

        #region Constructor Region

        public FormKey()
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
            using(FormKeyDetails formKeyDetails = new FormKeyDetails())
            {
                formKeyDetails.ShowDialog();

                if (formKeyDetails.Key != null)
                {
                    AddKey(formKeyDetails.Key);
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

                KeyData data = itemDataManager.KeyData[entity];
                KeyData newData = null;

                using(FormKeyDetails formKeyData = new FormKeyDetails())
                {
                    formKeyData.Key = data;
                    formKeyData.ShowDialog();

                    if (formKeyData.Key == null)
                        return;

                    if (formKeyData.Key.Name == entity)
                    {
                        itemDataManager.KeyData[entity] = formKeyData.Key;
                        FillListBox();
                        return;
                    }


                    newData = formKeyData.Key;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add new entry?", "New entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (itemDataManager.KeyData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify entry");
                    return;
                }

                lbDetails.Items.Add(newData);
                itemDataManager.KeyData.Add(newData.Name, newData);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if(lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + entity + "?", "Delete", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    itemDataManager.KeyData.Remove(entity);

                    if (File.Exists(FormMain.ItemPath + @"\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\" + entity + ".xml");
                }
            }
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemDataManager.KeyData.Keys)
                lbDetails.Items.Add(FormDetails.ItemDataManager.KeyData[s]);
        }

        private void AddKey(KeyData keyData)
        {
            if (FormDetails.ItemDataManager.KeyData.ContainsKey(keyData.Name))
            {
                DialogResult result = MessageBox.Show(keyData.Name + " already exists. Overwrite it?", "Existing key",MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemDataManager.KeyData[keyData.Name] = keyData;
                FillListBox();
                return;
            }

            itemDataManager.KeyData.Add(keyData.Name, keyData);
            lbDetails.Items.Add(keyData);
        }

        #endregion

        #region Virtual Methods region
        #endregion
    }
}
