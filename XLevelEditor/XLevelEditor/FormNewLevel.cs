using RpgLibrary.WorldClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XLevelEditor
{
    public partial class FormNewLevel : Form
    {
        #region Fields & Properties Region

        bool okPressed;
        LevelData levelData;

        public bool OKPressed
        {
            get { return okPressed; }
        }

        public LevelData LevelData
        {
            get { return levelData; }
        }

        #endregion

        #region Constructor Region

        public FormNewLevel()
        {
            InitializeComponent();

            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            SetDefaultValues();
        }

        #endregion

        #region Methods Region

        private void SetDefaultValues()
        {
            txtLevelName.Text = "Starting Level";
            txtMapName.Text = "Village";
            mtbWidth.Text = "100";
            mtbHeight.Text = "100";
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLevelName.Text))
            {
                MessageBox.Show("You must enter a name for the level","Missing level name");
                return;
            }

            if (string.IsNullOrEmpty(txtMapName.Text))
            {
                MessageBox.Show("You must enter a name for the map of the level.", "Missing map name");

                return;
            }

            int mapWidth = 0;
            int mapHeight = 0;

            if(!int.TryParse(mtbWidth.Text, out mapWidth) || mapWidth < 1)
            {
                MessageBox.Show("The width of the map must be > 1","Invalid map width");
                return;
            }

            if(!int.TryParse(mtbHeight.Text, out mapHeight) || mapHeight < 1)
            {
                MessageBox.Show("The height of the map must be > 1", "Invalid map height");
                return;
            }

            levelData = new LevelData(txtLevelName.Text, txtMapName.Text, mapWidth, mapHeight, new List<string>(), new List<string>(), new List<string>());
            okPressed = true;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            okPressed = false;
            this.Close();
        }

        #endregion

        #region Virtual Methods region
        #endregion


    }
}
