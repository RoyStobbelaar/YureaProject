using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.WorldClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XLevelEditor
{
    public partial class FormNewTileset : Form
    {

        #region Fields & Properties Region

        List<TilesetData> defaultTilesets;

        bool okPressed;
        TilesetData tilesetData;

        public bool OKPressed
        {
            get { return okPressed; }
        }

        public TilesetData TilesetData
        {
            get { return tilesetData; }
        }

        public List<TilesetData> DefaultTilesets
        {
            get { return defaultTilesets; }
        }

        #endregion

        #region Constructor Region

        public FormNewTileset()
        {
            InitializeComponent();

            btnSelectImage.Click += new EventHandler(btnSelectImage_Click);
            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            defaultTilesets = new List<TilesetData>();

            SetDefaultValues();
            SetDefaultTilesets();
        }

        #endregion

        #region Methods Region

        private void SetDefaultValues()
        {
            txtTilesetName.Text = "Village Tileset";
            mtbTileWidth.Text = "32";
            mtbTileHeight.Text = "32";
        }

        private void SetDefaultTilesets()
        {
            defaultTilesets.Clear();

            string path = Path.GetDirectoryName(Application.ExecutablePath);
            path += @"..\..\..\..\..\XLevelEditorContent\Tilesets\";
            string[] files = Directory.GetFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetFileName(files[i]) != "default")
                {
                    TilesetData newTileset = new TilesetData();
                    newTileset.TilesetName = Path.GetFileName(files[i]);
                    newTileset.TilesetImageName = files[i];
                    newTileset.TileHeightInPixels = 32;
                    newTileset.TileWidthInPixels = 32;

                    Image tileSet = (Image)Bitmap.FromFile(files[i]);

                    newTileset.TilesWide = tileSet.Width / 32;
                    newTileset.Tileshigh = tileSet.Height / 32;

                    defaultTilesets.Add(newTileset);
                }
            }
        }

        void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "Image Files|*.BMP;*.GIF;*.JPG;*.TGA;*.PNG";
            ofDialog.CheckFileExists = true;
            ofDialog.CheckPathExists = true;
            ofDialog.Multiselect = false;

            DialogResult result = ofDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                txtTilesetImage.Text = ofDialog.FileName;
            }
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTilesetName.Text))
            {
                MessageBox.Show("You must enter a name for the tileset");
                return;
            }

            if (string.IsNullOrEmpty(txtTilesetImage.Text))
            {
                MessageBox.Show("You must select an image for the tileset");
                return;
            }

            int tileWidth = 0;
            int tileHeight = 0;
            int tilesWide = 0;
            int tilesHigh = 0;

            if(!int.TryParse(mtbTileWidth.Text, out tileWidth))
            {
                MessageBox.Show("Tile width must be int");
                return;
            }
            else if(tileWidth < 0)
            {
                MessageBox.Show("Tile width must be greater than zero");
                return;
            }

            if(!int.TryParse(mtbTileHeight.Text,out tileHeight))
            {
                MessageBox.Show("Tile height must be int");
                return;
            }
            else if(tileHeight < 0)
            {
                MessageBox.Show("Tile height must be greater than zero");
                return;
            }

            Image tileSet = (Image)Bitmap.FromFile(txtTilesetImage.Text);

            tilesWide = tileSet.Width / tileWidth;
            tilesHigh = tileSet.Height / tileHeight;

            tilesetData = new TilesetData();

            tilesetData.TilesetName = txtTilesetName.Text;
            tilesetData.TilesetImageName = txtTilesetImage.Text;
            tilesetData.TileWidthInPixels = tileWidth;
            tilesetData.TileHeightInPixels = tileHeight;
            tilesetData.TilesWide = tilesWide;
            tilesetData.Tileshigh = tilesHigh;

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
