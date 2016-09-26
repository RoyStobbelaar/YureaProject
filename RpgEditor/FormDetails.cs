using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
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
using XRpgLibrary.CharacterClasses;
using XRpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormDetails : Form
    {

        #region Fields & Properties

        protected static ItemDataManager itemDataManager;
        protected static EntityDataManager entityDataManager;
        protected static SkillDataManager skillDataManager;

        public static ItemDataManager ItemDataManager
        {
            get { return itemDataManager; }
            private set { itemDataManager = value; }
        }

        public static EntityDataManager EntityDataManager
        {
            get { return entityDataManager; }
            private set { entityDataManager = value; }
        }

        public static SkillDataManager SkillDataManager
        {
            get { return skillDataManager; }
            private set { skillDataManager = value; }
        }

        #endregion

        #region Constructor Region

        public FormDetails()
        {
            InitializeComponent();

            if (FormDetails.itemDataManager == null)
                itemDataManager = new ItemDataManager();
            if (FormDetails.entityDataManager == null)
                entityDataManager = new EntityDataManager();

            this.FormClosing += new FormClosingEventHandler(FormDetails_FormClosing);
        }

        #endregion

        #region Event Method Region

        void FormDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }

            if(e.CloseReason == CloseReason.MdiFormClosing)
            {
                e.Cancel = false;
                this.Close();
            }
        }

        #endregion

        #region Methods Region

        public static void WriteEntityData()
        {
            foreach(string s in EntityDataManager.EntityData.Keys)
            {
                XnaSerializer.Serialize<EntityData>(
                    FormMain.ClassPath + @"\" + s + ".xml", 
                    EntityDataManager.EntityData[s]);
            }
        }

        public static void WriteItemData()
        {
            foreach(string s in ItemDataManager.ArmorData.Keys)
            {
                XnaSerializer.Serialize<ArmorData>(
                    FormMain.ItemPath + @"\Armor\" + s + ".xml",
                    ItemDataManager.ArmorData[s]);
            }

            foreach (string s in ItemDataManager.ShieldData.Keys)
            {
                XnaSerializer.Serialize<ShieldData>(
                    FormMain.ItemPath + @"\Shield\" + s + ".xml",
                    ItemDataManager.ShieldData[s]);
            }

            foreach (string s in ItemDataManager.WeaponData.Keys)
            {
                XnaSerializer.Serialize<WeaponData>(
                    FormMain.ItemPath + @"\Weapon\" + s + ".xml",
                    ItemDataManager.WeaponData[s]);
            }
        }

        public static void WriteKeyData()
        {
            foreach(string s in ItemDataManager.KeyData.Keys)
            {
                XnaSerializer.Serialize<KeyData>(FormMain.KeyPath + @"\" + s + ".xml", ItemDataManager.KeyData[s]);
            }
        }

        public static void WriteChestData()
        {
            foreach(string s in ItemDataManager.ChestData.Keys)
            {
                XnaSerializer.Serialize<ChestData>(FormMain.ChestPath + @"\" + s + ".xml", ItemDataManager.ChestData[s]);
            }
        }

        public static void WriteSkillData()
        {
            foreach(string s in SkillDataManager.SkillData.Keys)
            {
                XnaSerializer.Serialize<SkillData>(FormMain.SkillPath + @"\" + s + ".xml",SkillDataManager.SkillData[s]);
            }
        }

        public static void ReadEntityData()
        {
            entityDataManager = new EntityDataManager();

            string[] fileNames = Directory.GetFiles(FormMain.ClassPath, "*.xml");

            foreach(string s in fileNames)
            {
                EntityData entityData = XnaSerializer.Deserialize<EntityData>(s);
                entityDataManager.EntityData.Add(entityData.EntityName, entityData);
            }
        }

        public static void ReadItemData()
        {
            itemDataManager = new ItemDataManager();

            string[] fileNames = Directory.GetFiles(Path.Combine(FormMain.ItemPath, "Armor"), "*.xml");

            foreach(string s in fileNames)
            {
                ArmorData armorData = XnaSerializer.Deserialize<ArmorData>(s);
                itemDataManager.ArmorData.Add(armorData.Name, armorData);
            }

            fileNames = Directory.GetFiles(Path.Combine(FormMain.ItemPath, "Shield"), "*.xml");

            foreach (string s in fileNames)
            {
                ShieldData shieldData = XnaSerializer.Deserialize<ShieldData>(s);
                itemDataManager.ShieldData.Add(shieldData.Name, shieldData);
            }

            fileNames = Directory.GetFiles(Path.Combine(FormMain.ItemPath, "Weapon"), "*.xml");

            foreach (string s in fileNames)
            {
                WeaponData weaponData = XnaSerializer.Deserialize<WeaponData>(s);
                itemDataManager.WeaponData.Add(weaponData.Name, weaponData);
            }
        }

        public static void ReadKeyData()
        {
            string[] fileNames = Directory.GetFiles(FormMain.KeyPath, "*.xml");

            foreach(string s in fileNames)
            {
                KeyData keyData = XnaSerializer.Deserialize<KeyData>(s);
                itemDataManager.KeyData.Add(keyData.Name, keyData);
            }
        }

        public static void ReadChestData()
        {
            string[] fileNames = Directory.GetFiles(FormMain.ChestPath, "*.xml");

            foreach(string s in fileNames)
            {
                ChestData chestData = XnaSerializer.Deserialize<ChestData>(s);
                itemDataManager.ChestData.Add(chestData.Name, chestData);
            }
        }

        public static void ReadSkillData()
        {
            skillDataManager = new SkillDataManager();

            string[] fileNames = Directory.GetFiles(FormMain.SkillPath, "*.xml");

            foreach(string s in fileNames)
            {
                SkillData skillData = XnaSerializer.Deserialize<SkillData>(s);
                skillDataManager.SkillData.Add(skillData.Name, skillData);
            }
        }

        #endregion
    }
}
