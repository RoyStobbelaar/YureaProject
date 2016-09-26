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
    public partial class FormWeapon : FormDetails
    {

        #region Constructor Region

        public FormWeapon()
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
            using (FormWeaponDetails formWeaponDetails = new FormWeaponDetails())
            {
                formWeaponDetails.ShowDialog();
                if (formWeaponDetails.Weapon != null)
                {
                    AddWeapon(formWeaponDetails.Weapon);
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

                WeaponData data = itemDataManager.WeaponData[entity];
                WeaponData newData = null;

                using(FormWeaponDetails formWeaponData = new FormWeaponDetails())
                {
                    formWeaponData.Weapon = data;
                    formWeaponData.ShowDialog();

                    if (formWeaponData.Weapon == null)
                        return;

                    if (formWeaponData.Weapon.Name == entity)
                    {
                        itemDataManager.WeaponData[entity] = formWeaponData.Weapon;
                        FillListBox();
                        return;
                    }

                    newData = formWeaponData.Weapon;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if(itemDataManager.WeaponData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify entry");
                    return;
                }

                lbDetails.Items.Add(newData);
                itemDataManager.WeaponData.Add(newData.Name, newData);
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

                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    itemDataManager.WeaponData.Remove(entity);

                    if (File.Exists(FormMain.ItemPath + @"\Weapon\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\Weapon\" + entity + ".xml");

                }
            }
        }
        #endregion

        #region Methods Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemDataManager.WeaponData.Keys)
                lbDetails.Items.Add(FormDetails.ItemDataManager.WeaponData[s]);
        }

        private void AddWeapon(WeaponData weaponData)
        {
            if (FormDetails.ItemDataManager.WeaponData.ContainsKey(weaponData.Name))
            {
                DialogResult result = MessageBox.Show(weaponData.Name + " already exists. Overwrite it?","Existing weapon",MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemDataManager.WeaponData[weaponData.Name] = weaponData;
                FillListBox();
                return;

            }

            itemDataManager.WeaponData.Add(weaponData.Name, weaponData);
            lbDetails.Items.Add(weaponData);
        }

        #endregion
    }
}