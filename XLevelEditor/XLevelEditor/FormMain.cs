using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.WorldClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRpgLibrary.TileEngine;

using GDIBitmap = System.Drawing.Bitmap;
using GDIColor = System.Drawing.Color;
using GDIImage = System.Drawing.Image;
using GDIGraphics = System.Drawing.Graphics;
using GDIGraphicsUnit = System.Drawing.GraphicsUnit;
using GDIRectangle = System.Drawing.Rectangle;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace XLevelEditor
{
    public partial class FormMain : Form
    {
        #region Fields & Properties Region

        SpriteBatch spriteBatch;
        LevelData levelData;
        int frameCount;
        int brushWidth = 1;
        Color gridColor = Color.White;

        TileMap map;
        List<TileSet> tileSets = new List<TileSet>();
        List<ILayer> layers = new List<ILayer>();
        Point mouse = new Point();
        bool isMouseDown = false;
        bool trackMouse = false;

        public GraphicsDevice GraphicsDevice
        {
            get { return mapDisplay.GraphicsDevice; }
        }

        #endregion

        #region Constructor Region

        public FormMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormMain_Load);
            this.FormClosing += new FormClosingEventHandler(FormMain_Closing);

            tilesetToolStripMenuItem.Enabled = false;
            mapLayerToolStripMenuItem.Enabled = false;
            charactersToolStripMenuItem.Enabled = false;
            chestsToolStripMenuItem.Enabled = false;
            keysToolStripMenuItem.Enabled = false;

            newLevelToolStripMenuItem.Click += new EventHandler(newLevelToolStripMenuItem_Click);
            newTilesetToolStripMenuItem.Click += new EventHandler(newTilesetToolStripMenuItem_Click);
            newLayerToolStripMenuItem.Click += new EventHandler(newLayerToolStripMenuItem_Click);

            saveLevelToolStripMenuItem.Click += new EventHandler(saveLevelToolStripMenuItem_Click);

            openLevelToolStripMenuItem.Click += new EventHandler(openLevelToolStripMenuItem_Click);

            mapDisplay.OnInitialize += new EventHandler(mapDisplay_OnInitialize);
            mapDisplay.OnDraw += new EventHandler(mapDisplay_OnDraw);

            x1ToolStripMenuItem.Click += new EventHandler(x1ToolStripMenuItem_Click);
            x2ToolStripMenuItem.Click += new EventHandler(x2ToolStripMenuItem_Click);
            x4ToolStripMenuItem.Click += new EventHandler(x4ToolStripMenuItem_Click);
            x8ToolStripMenuItem.Click += new EventHandler(x8ToolStripMenuItem_Click);

            blackToolStripMenuItem.Click += new EventHandler(blackToolStripMenuItem_Click);
            blueToolStripMenuItem.Click += new EventHandler(blueToolStripMenuItem_Click);
            redToolStripMenuItem.Click += new EventHandler(redToolStripMenuItem_Click);
            greenToolStripMenuItem.Click += new EventHandler(greenToolStripMenuItem_Click);
            yellowToolStripMenuItem.Click += new EventHandler(yellowToolStripMenuItem_Click);
            whiteToolStripMenuItem.Click += new EventHandler(whiteToolStripMenuItem_Click);

            saveTilesetToolStripMenuItem.Click += new EventHandler(saveTilesetToolStripMenuItem_Click);
            saveLayerToolStripMenuItem.Click += new EventHandler(saveLayerToolStripMenuItem_Click);

            openTilesetToolStripMenuItem.Click += new EventHandler(openTilesetToolStripMenuItem_Click);
            openLayerToolStripMenuItem.Click += new EventHandler(openLayerToolStripMenuItem_Click);

            //Load defaults
            defaultTilesetsToolStripMenuItem.Click += new EventHandler(defaultTilesetsToolStripMenuItem_Click);
            defaultLayersToolStripMenuItem.Click += new EventHandler(defaultLayersToolStripMenuItem_Click);

        }

        #endregion
        #region Methods Region

        Camera camera;
        Engine engine;

        void FormMain_Load(object sender, EventArgs e)
        {
            //Application.Idle += new EventHandler(Application_Idle);
            lbTileset.SelectedIndexChanged += new EventHandler(lbTileset_SelectedIndexChanged);
            nudCurrentTile.ValueChanged += new EventHandler(nudCurrentTile_ValueChanged);

            Rectangle viewPort = new Rectangle(0, 0, mapDisplay.Width, mapDisplay.Height);
            camera = new Camera(viewPort);
            engine = new Engine(32, 32);

            controlTimer.Tick += new EventHandler(controlTimer_Tick);
            controlTimer.Enabled = true;
            controlTimer.Interval = 17;

            txtMapLocation.TextAlign = HorizontalAlignment.Center;
            pbTilesetPreview.MouseDown += new MouseEventHandler(pbTilesetPreview_MouseDown);

            mapDisplay.SizeChanged += new EventHandler(mapDisplay_SizeChanged);
        }

        void mapDisplay_SizeChanged(object sender, EventArgs e)
        {
            Rectangle viewPort = new Rectangle(0, 0, mapDisplay.Width, mapDisplay.Height);
            Vector2 cameraPosition = camera.Position;

            camera = new Camera(viewPort, cameraPosition);
            camera.LockCamera();
            mapDisplay.Invalidate();
        }

        void pbTilesetPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbTileset.Items.Count == 0)
                return;

            if (e.Button != MouseButtons.Left)
                return;

            int index = lbTileset.SelectedIndex;

            float xScale = (float)tileSetImages[index].Width / pbTilesetPreview.Width;
            float yScale = (float)tileSetImages[index].Height / pbTilesetPreview.Height;

            Point previewPoint = new Point(e.X, e.Y);

            Point tilesetPoint = new Point((int)(previewPoint.X * xScale), (int)(previewPoint.Y * yScale));

            Point tile = new Point(tilesetPoint.X / tileSets[index].TileWidth, tilesetPoint.Y / tileSets[index].TileHeight);

            nudCurrentTile.Value = tile.Y * tileSets[index].TilesWide + tile.X;
        }

        void controlTimer_Tick(object sender, EventArgs e)
        {
            frameCount = ++frameCount % 6;
            mapDisplay.Invalidate();
            Logic();
        }

        void nudCurrentTile_ValueChanged(object sender, EventArgs e)
        {
            if (lbTileset.SelectedItem != null)
            {
                FillPreviews();
            }
        }

        void lbTileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTileset.SelectedItem != null)
            {
                nudCurrentTile.Value = 0;
                nudCurrentTile.Maximum = tileSets[lbTileset.SelectedIndex].SourceRectangles.Length - 1;
                FillPreviews();
            }
        }

        private void FillPreviews()
        {
            int selected = lbTileset.SelectedIndex;
            int tile = (int)nudCurrentTile.Value;

            GDIImage preview = (GDIImage)new GDIBitmap(pbTilePreview.Width, pbTilePreview.Height);

            GDIRectangle dest = new GDIRectangle(0, 0, preview.Width, preview.Height);
            GDIRectangle source = new GDIRectangle(tileSets[selected].SourceRectangles[tile].X,
                tileSets[selected].SourceRectangles[tile].Y,
                tileSets[selected].SourceRectangles[tile].Width,
                tileSets[selected].SourceRectangles[tile].Height);

            GDIGraphics g = GDIGraphics.FromImage(preview);
            g.DrawImage(tileSetImages[selected], dest, source, GDIGraphicsUnit.Pixel);

            pbTilesetPreview.Image = tileSetImages[selected];
            pbTilePreview.Image = preview;
        }

        void FormMain_Closing(object sender, FormClosingEventArgs e)
        {

        }

        void Application_Idle(object sender, EventArgs e)
        {
            mapDisplay.Invalidate();
        }

        void newLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(FormNewLevel frmNewLevel = new FormNewLevel())
            {
                frmNewLevel.ShowDialog();

                if (frmNewLevel.OKPressed)
                {
                    levelData = frmNewLevel.LevelData;
                    tilesetToolStripMenuItem.Enabled = true;
                }
            }
        }

        void defaultTilesetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewTileset frmNewTileSet = new FormNewTileset())
            {
                foreach (TilesetData data in frmNewTileSet.DefaultTilesets)
                {
                    try
                    {
                        GDIImage image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
                        tileSetImages.Add(image);

                        Stream stream = new FileStream(data.TilesetImageName, FileMode.Open, FileAccess.Read);
                        Texture2D texture = Texture2D.FromStream(GraphicsDevice, stream);
                        TileSet tileset = new TileSet(texture, data.TilesWide, data.Tileshigh, data.TileWidthInPixels, data.TileHeightInPixels);

                        tileSets.Add(tileset);
                        tileSetData.Add(data);

                        if (map != null)
                            map.AddTileset(tileset);

                        stream.Close();
                        stream.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occured : " + ex.Message, "Error reading file");
                        return;
                    }

                    lbTileset.Items.Add(data.TilesetName);

                    if (lbTileset.SelectedItem != null)
                        lbTileset.SelectedIndex = 0;
                }

                mapLayerToolStripMenuItem.Enabled = true;
            }
        }

        List<GDIImage> tileSetImages = new List<GDIImage>();
        List<TilesetData> tileSetData = new List<TilesetData>();
        void newTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(FormNewTileset frmNewTileSet = new FormNewTileset())
            {
                frmNewTileSet.ShowDialog();

                if (frmNewTileSet.OKPressed)
                {
                    TilesetData data = frmNewTileSet.TilesetData;

                    try
                    {
                        GDIImage image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
                        tileSetImages.Add(image);

                        Stream stream = new FileStream(data.TilesetImageName, FileMode.Open, FileAccess.Read);
                        Texture2D texture = Texture2D.FromStream(GraphicsDevice, stream);
                        TileSet tileset = new TileSet(texture, data.TilesWide, data.Tileshigh, data.TileWidthInPixels, data.TileHeightInPixels);

                        tileSets.Add(tileset);
                        tileSetData.Add(data);

                        if (map != null)
                            map.AddTileset(tileset);

                        stream.Close();
                        stream.Dispose();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("An error has occured : " + ex.Message, "Error reading file");
                        return;
                    }

                    lbTileset.Items.Add(data.TilesetName);

                    if (lbTileset.SelectedItem != null)
                        lbTileset.SelectedIndex = 0;

                    mapLayerToolStripMenuItem.Enabled = true;
                }
            }
        }

        void newLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewLayer frmNewLayer = new FormNewLayer(levelData.MapWidth,levelData.MapHeight))
            {
                frmNewLayer.ShowDialog();

                if (frmNewLayer.OkPressed)
                {
                    MapLayerData data = frmNewLayer.MapLayerData;

                    if (clbLayers.Items.Contains(data.MapLayerName))
                    {
                        MessageBox.Show("Layer already exists","Existing layer");
                        return;
                    }

                    MapLayer layer = MapLayer.FromMapLayerData(data);
                    clbLayers.Items.Add(data.MapLayerName,true);
                    clbLayers.SelectedIndex = clbLayers.Items.Count - 1;

                    layers.Add(layer);

                    if (map == null)
                    {
                        map = new TileMap(tileSets[0], (MapLayer)layers[0]);

                        for (int i = 1; i < tileSets.Count; i++)
                            map.AddTileset(tileSets[i]);

                        for (int i = 1; i < layers.Count; i++)
                            map.AddLayer((MapLayer)layers[i]);

                    }

                    charactersToolStripMenuItem.Enabled = true;
                    chestsToolStripMenuItem.Enabled = true;
                    keysToolStripMenuItem.Enabled = true;
                }
            }
        }

        void defaultLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewLayer frmNewLayer = new FormNewLayer(levelData.MapWidth, levelData.MapHeight))
            {
                foreach (MapLayerData data in frmNewLayer.DefaultLayerData)
                {

                    if (clbLayers.Items.Contains(data.MapLayerName))
                    {
                        MessageBox.Show("Layer already exists", "Existing layer");
                        return;
                    }

                    MapLayer layer = MapLayer.FromMapLayerData(data);
                    clbLayers.Items.Add(data.MapLayerName, true);

                    layers.Add(layer);

                    if (map == null)
                    {
                        map = new TileMap(tileSets[0], (MapLayer)layers[0]);

                        for (int i = 1; i < tileSets.Count; i++)
                            map.AddTileset(tileSets[i]);

                        for (int i = 1; i < layers.Count; i++)
                            map.AddLayer((MapLayer)layers[i]);
                    }

                    /*Set all maptiles to -1, -1 (nothing)*/
                    for (int y = 0; y < levelData.MapHeight; y++)
                        for (int x = 0; x < levelData.MapWidth; x++)
                            data.SetTile(x, y, -1, -1);
                }

                clbLayers.SelectedIndex = 0;


                charactersToolStripMenuItem.Enabled = true;
                    chestsToolStripMenuItem.Enabled = true;
                    keysToolStripMenuItem.Enabled = true;
                }
        }

        Texture2D cursor;
        Texture2D grid;
        Texture2D shadow;
        Vector2 shadowPosition = Vector2.Zero;

        void mapDisplay_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            shadow = new Texture2D(GraphicsDevice, 20, 20, false, SurfaceFormat.Color);
            Color[] data = new Color[shadow.Width * shadow.Height];
            Color tint = Color.LightSteelBlue;
            tint.A = 25;

            for (int i = 0; i < shadow.Width * shadow.Height; i++)
                data[i] = tint;

            shadow.SetData<Color>(data);

            mapDisplay.MouseEnter += new EventHandler(mapDisplay_MouseEnter);
            mapDisplay.MouseLeave += new EventHandler(mapDisplay_MouseLeave);
            mapDisplay.MouseMove += new MouseEventHandler(mapDisplay_MouseMove);
            mapDisplay.MouseDown += new MouseEventHandler(mapDisplay_MouseDown);
            mapDisplay.MouseUp += new MouseEventHandler(mapDisplay_MouseUp);

            //try
            //{
            //    using (Stream stream = new FileStream(@"Content\grid.png", FileMode.Open, FileAccess.Read))
            //    {
            //        grid = Texture2D.FromStream(GraphicsDevice, stream);
            //        stream.Close();
            //    }

            //    using (Stream stream = new FileStream(@"Content\cursor.png", FileMode.Open, FileAccess.Read))
            //    {
            //        cursor = Texture2D.FromStream(GraphicsDevice, stream);
            //        stream.Close();
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error reading image");
            //    grid = null;
            //    cursor = null;
            //}
        }

        void mapDisplay_OnDraw(object sender, EventArgs e)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Render();
            Logic();
        }

        void mapDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = false;
        }

        void mapDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = true;
        }

        void mapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            mouse.X = e.X;
            mouse.Y = e.Y;
        }

        void mapDisplay_MouseLeave(object sender, EventArgs e)
        {
            trackMouse = false;
        }

        void mapDisplay_MouseEnter(object sender, EventArgs e)
        {
            trackMouse = true;
        }

        private void Render()
        {
            for(int i = 0; i < layers.Count; i++)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.Transformation);
                if (clbLayers.GetItemChecked(i))
                    layers[i].Draw(spriteBatch, camera, tileSets);

                Rectangle destination = new Rectangle((int)shadowPosition.X * Engine.TileWidth, (int)shadowPosition.Y * Engine.TileHeight, brushWidth * Engine.TileWidth, brushWidth * Engine.TileHeight);
                Color tint = Color.White;
                tint.A = 1;

                spriteBatch.Draw(shadow, destination, tint);
                spriteBatch.End();
            }

            DrawDisplay();
        }

        private void DrawDisplay()
        {
            if (map == null)
                return;

            Rectangle destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);


            // Somewhere in your LoadContent() method:
            grid = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            grid.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it

            if (displayGridToolStripMenuItem.Checked)
            {
                int maxX = mapDisplay.Width / Engine.TileWidth + 1;
                int maxY = mapDisplay.Height / Engine.TileHeight + 1;

                spriteBatch.Begin();

                for(int y = 0; y < maxY; y++)
                {
                    destination.Y = y * Engine.TileHeight;

                    for(int x = 0; x < maxX; x++)
                    {

                        destination.X = x * Engine.TileWidth;
                        DrawBorder(destination, 1, gridColor);
                        //spriteBatch.Draw(grid, destination, Color.White);
                        //spriteBatch.Draw(grid, destination, gridColor);
                    }
                }

                spriteBatch.End();
            }
            spriteBatch.Begin();

            destination.X = mouse.X;
            destination.Y = mouse.Y;

            //if (rbDraw.Checked)
            //    spriteBatch.Draw(tileSets[lbTileset.SelectedIndex].Texture, destination, tileSets[lbTileset.SelectedIndex].SourceRectangles[(int)nudCurrentTile.Value], Color.White);

            //spriteBatch.Draw(cursor, destination, Color.White);

            spriteBatch.End();
        }

        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            spriteBatch.Draw(grid, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(grid, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(grid, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(grid, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }

        private void Logic()
        {
            if (layers.Count == 0)
                return;

            Vector2 position = camera.Position;

            if (trackMouse)
            {
                if (frameCount == 0)
                {
                    if (mouse.X < Engine.TileWidth)
                        position.X -= Engine.TileWidth;

                    if (mouse.X > mapDisplay.Width - Engine.TileWidth)
                        position.X += Engine.TileWidth;

                    if (mouse.Y < Engine.TileHeight)
                        position.Y -= Engine.TileHeight;

                    if (mouse.Y > mapDisplay.Height - Engine.TileHeight)
                        position.Y += Engine.TileHeight;

                    camera.Position = position;
                    camera.LockCamera();
                }
                position.X = mouse.X + camera.Position.X;
                position.Y = mouse.Y + camera.Position.Y;

                Point tile = Engine.VectorToCell(position);
                shadowPosition = new Vector2(tile.X, tile.Y);

                txtMapLocation.Text = "( " + tile.X.ToString() + ", " + tile.Y.ToString() + " )"; 

                if (isMouseDown)
                {
                    if (rbDraw.Checked)
                    {
                        SetTiles(tile, (int)nudCurrentTile.Value, lbTileset.SelectedIndex);
                        //layers[clbLayers.SelectedIndex].SetTile(tile.X, tile.Y, (int)nudCurrentTile.Value, lbTileset.SelectedIndex);
                    }
                    if (rbErase.Checked)
                    {
                        SetTiles(tile, -1, -1);
                        //layers[clbLayers.SelectedIndex].SetTile(tile.X, tile.Y, -1, -1);
                    }
                }
            }
        }

        private void SetTiles(Point tile, int tileIndex, int tileset)
        {
            int selected = clbLayers.SelectedIndex;

            if (layers[selected] is MapLayer)
            {
                if (tile.X < 0 || tile.Y < 0)
                    return;

                for (int y = 0; y < brushWidth; y++)
                {
                    if (tile.Y + y >= ((MapLayer)layers[selected]).Height)
                        break;

                    for (int x = 0; x < brushWidth; x++)
                    {
                        if (tile.X + x < ((MapLayer)layers[selected]).Width)
                            ((MapLayer)layers[selected]).SetTile(tile.X + x, tile.Y + y, tileIndex, tileset);

                        if (rbLinkTile.Checked)
                            ((MapLayer)layers[selected]).SetLink(tile.X + x, tile.Y + y,txtLinkedTile.Text);
                    }
                }
            }
        }

        void saveLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map == null)
                return;

            List<MapLayerData> mapLayerData = new List<MapLayerData>();

            for(int i=0; i < clbLayers.Items.Count; i++)
            {
                if (layers[i] is MapLayer)
                {

                    MapLayerData data = new MapLayerData(clbLayers.Items[i].ToString(), ((MapLayer)layers[i]).Width, ((MapLayer)layers[i]).Height, ((MapLayer)layers[i]).LinkedTiles);

                    for (int y = 0; y < ((MapLayer)layers[i]).Height; y++)
                    {
                        for (int x = 0; x < ((MapLayer)layers[i]).Width; x++)
                        {
                            data.SetTile(x, y, ((MapLayer)layers[i]).GetTile(x, y).TileIndex, ((MapLayer)layers[i]).GetTile(x, y).Tileset);
                        }
                    }
                    
                    mapLayerData.Add(data);
                }
            }

            MapData mapData = new MapData(levelData.MapName, tileSetData, mapLayerData);

            FolderBrowserDialog fbDialog = new FolderBrowserDialog();

            fbDialog.Description = "Select Game Folder";
            fbDialog.SelectedPath = Application.StartupPath;

            DialogResult result = fbDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                if(!File.Exists(fbDialog.SelectedPath + @"\Game.xml"))
                {
                    MessageBox.Show("Game not found","Error");
                    return;
                }

                string LevelPath = Path.Combine(fbDialog.SelectedPath, @"Levels\");
                string MapPath = Path.Combine(LevelPath, @"Maps\");

                if (!Directory.Exists(LevelPath))
                    Directory.CreateDirectory(LevelPath);

                if (!Directory.Exists(MapPath))
                    Directory.CreateDirectory(MapPath);

                XnaSerializer.Serialize<LevelData>(LevelPath + levelData.LevelName + ".xml", levelData);
                XnaSerializer.Serialize<MapData>(MapPath + mapData.MapName + ".xml", mapData);
            }
        }

        void openLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "Level Files (*.xml)|*.xml";
            ofDialog.CheckFileExists = true;
            ofDialog.CheckPathExists = true;

            DialogResult result = ofDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            string path = Path.GetDirectoryName(ofDialog.FileName);

            LevelData newLevel = null;
            MapData mapData = null;

            try
            {
                newLevel = XnaSerializer.Deserialize<LevelData>(ofDialog.FileName);
                mapData = XnaSerializer.Deserialize<MapData>(path + @"\Maps\" + newLevel.MapName + ".xml");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error reading level");
                return;
            }

            tileSetImages.Clear();
            tileSetData.Clear();
            tileSets.Clear();
            layers.Clear();
            lbTileset.Items.Clear();
            clbLayers.Items.Clear();

            levelData = newLevel;

            foreach(TilesetData data in mapData.Tilesets)
            {
                Texture2D texture = null;
                tileSetData.Add(data);
                lbTileset.Items.Add(data.TilesetName);

                GDIImage image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
                tileSetImages.Add(image);

                using(Stream stream = new FileStream(data.TilesetImageName, FileMode.Open, FileAccess.Read))
                {
                    texture = Texture2D.FromStream(GraphicsDevice, stream);
                    tileSets.Add(new TileSet(texture, data.TilesWide, data.Tileshigh, data.TileWidthInPixels, data.TileHeightInPixels));
                }
            }

            foreach(MapLayerData data in mapData.Layers)
            {
                clbLayers.Items.Add(data.MapLayerName, true);
                layers.Add(MapLayer.FromMapLayerData(data));
            }

            lbTileset.SelectedIndex = 0;
            clbLayers.SelectedIndex = 0;
            nudCurrentTile.Value = 0;

            map = new TileMap(tileSets[0], (MapLayer)layers[0]);

            for (int i = 1; i < tileSets.Count; i++)
                map.AddTileset(tileSets[i]);

            for (int i = 1; i < layers.Count; i++)
                map.AddLayer((MapLayer)layers[i]);

            tilesetToolStripMenuItem.Enabled = true;
            mapLayerToolStripMenuItem.Enabled = true;
            charactersToolStripMenuItem.Enabled = true;
            chestsToolStripMenuItem.Enabled = true;
            keysToolStripMenuItem.Enabled = true;
        }

        #endregion
        #region Brush Methods region

        void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = true;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = false;

            brushWidth = 1;
        }

        void x2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = true;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = false;

            brushWidth = 2;
        }

        void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = true;
            x8ToolStripMenuItem.Checked = false;

            brushWidth = 4;
        }

        void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = true;

            brushWidth = 8;
        }

        #endregion

        #region Color methods

        void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Black;
            blackToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Blue;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Red;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = true;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Green;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = true;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Yellow;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = true;
            whiteToolStripMenuItem.Checked = false;
        }

        void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.White;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = true;
        }

        #endregion

        #region Open/Save Methods for tiles/layers

        void saveTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tileSetData.Count == 0)
                return;
            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Filter = "Tileset Data (*.tdat)|*.tdat";
            sfDialog.CheckPathExists = true;
            sfDialog.OverwritePrompt = true;
            sfDialog.ValidateNames = true;

            DialogResult result = sfDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            try
            {
                XnaSerializer.Serialize<TilesetData>(sfDialog.FileName, tileSetData[lbTileset.SelectedIndex]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error saving tileset");
            }
        }

        void saveLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layers.Count == 0)
                return;

            if (layers[clbLayers.SelectedIndex] is MapLayer)
            {

                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.Filter = "Map Layer Data (*.mldt)|*.mldt";
                sfDialog.CheckPathExists = true;
                sfDialog.OverwritePrompt = true;
                sfDialog.ValidateNames = true;

                DialogResult result = sfDialog.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                MapLayerData data = new MapLayerData(clbLayers.SelectedItem.ToString(), ((MapLayer)layers[clbLayers.SelectedIndex]).Width, ((MapLayer)layers[clbLayers.SelectedIndex]).Height);

                for (int y = 0; y < ((MapLayer)layers[clbLayers.SelectedIndex]).Height; y++)
                {
                    for (int x = 0; x < ((MapLayer)layers[clbLayers.SelectedIndex]).Width; x++)
                    {
                        data.SetTile(x, y, ((MapLayer)layers[clbLayers.SelectedIndex]).GetTile(x, y).TileIndex, ((MapLayer)layers[clbLayers.SelectedIndex]).GetTile(x, y).Tileset);
                    }
                }

                try
                {
                    XnaSerializer.Serialize<MapLayerData>(sfDialog.FileName, data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error saving map layer data");
                }
            }
        }

        void openTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "Tileset Data (*.tdat)|*.tdat";
            ofDialog.CheckPathExists = true;
            ofDialog.CheckFileExists = true;

            DialogResult result = ofDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            TilesetData data = null;
            Texture2D texture = null;
            TileSet tileset = null;
            GDIImage image = null;

            try
            {
                data = XnaSerializer.Deserialize<TilesetData>(ofDialog.FileName);
                using(Stream stream = new FileStream(data.TilesetImageName, FileMode.Open, FileAccess.Read))
                {
                    texture = Texture2D.FromStream(GraphicsDevice, stream);
                    stream.Close();
                }

                image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);

                tileset = new TileSet(texture, data.TilesWide, data.Tileshigh, data.TileWidthInPixels, data.TileHeightInPixels);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error reading tileset");
                return;
            }

            for(int i = 0; i < lbTileset.Items.Count; i++)
            {
                if(lbTileset.Items[i].ToString() == data.TilesetName)
                {
                    MessageBox.Show("Level already contains a tileset with this name","Existing tileset");
                    return;
                }
            }

            tileSetData.Add(data);
            tileSets.Add(tileset);

            lbTileset.Items.Add(data.TilesetName);

            pbTilesetPreview.Image = image;
            tileSetImages.Add(image);

            lbTileset.SelectedIndex = lbTileset.Items.Count - 1;
            nudCurrentTile.Value = 0;

            mapLayerToolStripMenuItem.Enabled = true;
        }

        void openLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "Map Layer Data (*.mldt)|*.mldt";
            ofDialog.CheckPathExists = true;
            ofDialog.CheckFileExists = true;

            DialogResult result = ofDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            MapLayerData data = null;

            try
            {
                data = XnaSerializer.Deserialize<MapLayerData>(ofDialog.FileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error reading map layer");
                return;
            }

            for(int i = 0; i < clbLayers.Items.Count; i++)
            {
                if (clbLayers.Items[i].ToString() == data.MapLayerName)
                {
                    MessageBox.Show("Layer by that name already exists","Existing layer");
                    return;
                }
            }

            clbLayers.Items.Add(data.MapLayerName, true);
            layers.Add(MapLayer.FromMapLayerData(data));
            if (map == null)
            {
                map = new TileMap(tileSets[0], (MapLayer)layers[0]);

                for (int i = 1; i < tileSets.Count; i++)
                    map.AddTileset(tileSets[i]);
            }
        }

        #endregion
    }
}
