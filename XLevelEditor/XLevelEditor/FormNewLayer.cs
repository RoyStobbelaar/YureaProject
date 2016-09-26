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
    public partial class FormNewLayer : Form
    {

        #region Fields & Properties Region

        bool okPressed;
        int LayerWidth;
        int LayerHeight;

        MapLayerData mapLayerData;

        List<MapLayerData> defaultLayerData;

        public bool OkPressed
        {
            get { return okPressed; }
        }

        public MapLayerData MapLayerData
        {
            get { return mapLayerData; }
        }

        public List<MapLayerData> DefaultLayerData
        {
            get { return defaultLayerData; }
        }

        #endregion

        #region Constructor Region

        public FormNewLayer(int width, int height)
        {
            InitializeComponent();

            LayerWidth = width;
            LayerHeight = height;

            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            defaultLayerData = new List<MapLayerData>();

            LoadDefaultLayers(width, height);
        }

        #endregion
        #region Methods Region

        void LoadDefaultLayers(int width, int height)
        {
            defaultLayerData.Clear();

            defaultLayerData.Add(new MapLayerData("BaseLayer", width, height));
            defaultLayerData.Add(new MapLayerData("SplatterLayer", width, height));
            defaultLayerData.Add(new MapLayerData("CollisionLayer", width, height));
            defaultLayerData.Add(new MapLayerData("DecorationLayer", width, height));
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLayerName.Text))
            {
                MessageBox.Show("You must enter a name for a label","Missing layer name");
                return;
            }

            if (cbFill.Checked)
            {
                mapLayerData = new MapLayerData(txtLayerName.Text, LayerWidth, LayerHeight, (int)nudTile.Value, (int)nudTileset.Value);
            }
            else
            {
                mapLayerData = new MapLayerData(txtLayerName.Text, LayerWidth, LayerHeight);
            }

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
