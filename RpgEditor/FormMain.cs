using RpgLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RpgEditor
{
    public partial class FormMain : Form
    {

        #region Fields & Properties

        RolePlayingGame rolePlayingGame;
        FormClasses formClasses;
        FormWeapon formWeapon;
        FormArmor formArmor;
        FormShield formShield;
        FormChest formChest;
        FormKey formKey;
        FormSkill formSkill;

        static string gamePath = "";
        static string classPath = "";
        static string itemPath = "";
        static string chestPath = "";
        static string keyPath = "";
        static string skillPath = "";

        public static string GamePath
        {
            get { return gamePath; }
        }

        public static string ClassPath
        {
            get { return classPath; }
        }

        public static string ItemPath
        {
            get { return itemPath; }
        }

        public static string ChestPath
        {
            get { return chestPath; }
        }

        public static string KeyPath
        {
            get { return keyPath; }
        }

        public static string SkillPath
        {
            get { return skillPath; }
        }

        #endregion

        #region Constructor Region

        public FormMain()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(FormMain_Closing);

            newGameToolStripMenuItem.Click += new EventHandler(newGameToolStripMenuItem_Click);
            openGameToolStripMenuItem.Click += new EventHandler(openGameToolStripMenuItem_Click);
            saveGameToolStripMenuItem.Click += new EventHandler(saveGameToolStripMenuItem_Click);
            exitGameToolStripMenuItem.Click += new EventHandler(exitGameToolStripMenuItem_Click);

            classesToolStripMenuItem.Click += new EventHandler(classesToolStripMenuItem_Click);
            armorToolStripMenuItem.Click += new EventHandler(armorToolStripMenuItem_Click);
            shieldToolStripMenuItem.Click += new EventHandler(shieldToolStripMenuItem_Click);
            weaponsToolStripMenuItem.Click += new EventHandler(weaponsToolStripMenuItem_Click);

            keysToolStripMenuItem.Click += new EventHandler(keysToolStripMenuItem_Click);
            chestToolStripMenuItem.Click += new EventHandler(chestToolStripMenuItem_Click);

            skillsToolStripMenuItem.Click += new EventHandler(skillsToolStripMenuItem_Click);
        }

        #endregion

        #region Event Methods

        void FormMain_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Unsaved changes will be lost. Ya sure you wish to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rolePlayingGame != null)
            {
                try
                {
                    XnaSerializer.Serialize<RolePlayingGame>(gamePath + @"\Game.xml", rolePlayingGame);
                    FormDetails.WriteEntityData();
                    FormDetails.WriteItemData();
                    FormDetails.WriteChestData();
                    FormDetails.WriteKeyData();
                    FormDetails.WriteSkillData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error saving game");
                }
            }
        }

        private void openGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            folderDialog.Description = "Select game folder";
            folderDialog.SelectedPath = Application.StartupPath;

            bool tryAgain = false;

            do
            {
                DialogResult folderResult = folderDialog.ShowDialog();
                DialogResult msgBoxResult;

                if (folderResult == DialogResult.OK)
                {
                    if (File.Exists(folderDialog.SelectedPath + @"\Game\Game.xml"))
                    {

                        try
                        {
                            OpenGame(folderDialog.SelectedPath);
                            tryAgain = false;
                        }
                        catch (Exception ex)
                        {
                            msgBoxResult = MessageBox.Show(ex.ToString(), "Error opening game.", MessageBoxButtons.RetryCancel);
                            if (msgBoxResult == DialogResult.Cancel)
                                tryAgain = false;
                            else if (msgBoxResult == DialogResult.Retry)
                                tryAgain = true;
                        }
                    }
                    else
                    {
                        msgBoxResult = MessageBox.Show("Game not found, try again?", "Game does not exist", MessageBoxButtons.RetryCancel);
                        if (msgBoxResult == DialogResult.Cancel)
                            tryAgain = false;
                        else if (msgBoxResult == DialogResult.Retry)
                            tryAgain = true;
                    }
                }
            } while (tryAgain);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewGame formNewGame = new FormNewGame())
            {
                DialogResult result = formNewGame.ShowDialog();
                if(result == DialogResult.OK && formNewGame.RolePlayingGame != null)
                {
                    FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                    folderDialog.Description = "Select folder to create game in";
                    folderDialog.SelectedPath = Application.StartupPath;

                    DialogResult folderResult = folderDialog.ShowDialog();

                    if(folderResult == DialogResult.OK)
                    {
                        try
                        {
                            gamePath = Path.Combine(folderDialog.SelectedPath, "Game");
                            classPath = Path.Combine(gamePath, "Classes");
                            itemPath = Path.Combine(gamePath, "Items");
                            keyPath = Path.Combine(gamePath, "Keys");
                            chestPath = Path.Combine(gamePath, "Chests");
                            skillPath = Path.Combine(gamePath, "Skills");

                            if (Directory.Exists(gamePath))
                                throw new Exception("Selected directory already exists");

                            Directory.CreateDirectory(gamePath);
                            Directory.CreateDirectory(classPath);
                            Directory.CreateDirectory(itemPath + @"\Armor");
                            Directory.CreateDirectory(itemPath + @"\Shield");
                            Directory.CreateDirectory(itemPath + @"\Weapon");
                            Directory.CreateDirectory(keyPath);
                            Directory.CreateDirectory(chestPath);
                            Directory.CreateDirectory(skillPath);


                            rolePlayingGame = formNewGame.RolePlayingGame;
                            XnaSerializer.Serialize<RolePlayingGame>(gamePath + @"\Game.xml",rolePlayingGame);

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return;
                        }
                    }

                    classesToolStripMenuItem.Enabled = true;
                    itemsToolStripMenuItem.Enabled = true;
                    keysToolStripMenuItem.Enabled = true;
                    chestToolStripMenuItem.Enabled = true;
                    skillsToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formClasses == null)
            {
                formClasses = new FormClasses();
                formClasses.MdiParent = this;
            }
            formClasses.Show();
            formClasses.BringToFront();
        }

        private void weaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formWeapon == null)
            {
                formWeapon = new FormWeapon();
                formWeapon.MdiParent = this;
            }

            formWeapon.Show();
            formWeapon.BringToFront();
        }

        private void shieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formShield == null)
            {
                formShield = new FormShield();
                formShield.MdiParent = this;
            }

            formShield.Show();
            formShield.BringToFront();
        }

        private void armorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formArmor == null)
            {
                formArmor = new FormArmor();
                formArmor.MdiParent = this;
            }

            formArmor.Show();
            formArmor.BringToFront();
        }

        private void chestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formChest == null)
            {
                formChest = new FormChest();
                formChest.MdiParent = this;
            }

            formChest.Show();
            formChest.BringToFront();
        }

        private void keysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formKey == null)
            {
                formKey = new FormKey();
                formKey.MdiParent = this;
            }

            formKey.Show();
            formKey.BringToFront();
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formSkill == null)
            {
                formSkill = new FormSkill();
                formSkill.MdiParent = this;
            }

            formSkill.Show();
            formSkill.BringToFront();
        }

        #endregion

        #region Methods Region

        private void OpenGame(string path)
        {
            gamePath = Path.Combine(path, "Game");
            classPath = Path.Combine(gamePath, "Classes");
            itemPath = Path.Combine(gamePath, "Items");
            keyPath = Path.Combine(gamePath, "Keys");
            chestPath = Path.Combine(gamePath, "Chests");
            skillPath = Path.Combine(gamePath, "Skills");

            if (!Directory.Exists(keyPath))
            {
                Directory.CreateDirectory(keyPath);
            }

            if (!Directory.Exists(chestPath))
            {
                Directory.CreateDirectory(chestPath);
            }

            if (!Directory.Exists(skillPath))
            {
                Directory.CreateDirectory(skillPath);
            }

            rolePlayingGame = XnaSerializer.Deserialize<RolePlayingGame>(gamePath + @"\Game.xml");

            FormDetails.ReadEntityData();
            FormDetails.ReadItemData();
            FormDetails.ReadKeyData();
            FormDetails.ReadChestData();
            FormDetails.ReadSkillData();

            PrepareForms();
        }

        private void PrepareForms()
        {
            if(formClasses == null)
            {
                formClasses = new FormClasses();
                formClasses.MdiParent = this;
            }

            formClasses.FillListBox();

            if(formArmor == null)
            {
                formArmor = new FormArmor();
                formArmor.MdiParent = this;
            }

            formArmor.FillListBox();

            if(formShield == null)
            {
                formShield = new FormShield();
                formShield.MdiParent = this;
            }

            formShield.FillListBox();

            if(formWeapon == null)
            {
                formWeapon = new FormWeapon();
                formWeapon.MdiParent = this;
            }

            formWeapon.FillListBox();

            if(formKey == null)
            {
                formKey = new FormKey();
                formKey.MdiParent = this;
            }

            formKey.FillListBox();

            if (formChest == null)
            {
                formChest = new FormChest();
                formChest.MdiParent = this;
            }

            formChest.FillListBox();

            if(formSkill == null)
            {
                formSkill = new FormSkill();
                formSkill.MdiParent = this;
            }

            formSkill.FillListBox();


            classesToolStripMenuItem.Enabled = true;
            itemsToolStripMenuItem.Enabled = true;
            chestToolStripMenuItem.Enabled = true;
            keysToolStripMenuItem.Enabled = true;
            skillsToolStripMenuItem.Enabled = true;

        }

        #endregion
    }
}
