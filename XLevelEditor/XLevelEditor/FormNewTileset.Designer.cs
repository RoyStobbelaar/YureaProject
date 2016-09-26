namespace XLevelEditor
{
    partial class FormNewTileset
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTilesetName = new System.Windows.Forms.Label();
            this.txtTilesetName = new System.Windows.Forms.TextBox();
            this.lblTilesetImageName = new System.Windows.Forms.Label();
            this.txtTilesetImage = new System.Windows.Forms.TextBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.lblTileWidth = new System.Windows.Forms.Label();
            this.mtbTileWidth = new System.Windows.Forms.MaskedTextBox();
            this.lblTileHeight = new System.Windows.Forms.Label();
            this.mtbTileHeight = new System.Windows.Forms.MaskedTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTilesetName
            // 
            this.lblTilesetName.AutoSize = true;
            this.lblTilesetName.Location = new System.Drawing.Point(54, 8);
            this.lblTilesetName.Name = "lblTilesetName";
            this.lblTilesetName.Size = new System.Drawing.Size(72, 13);
            this.lblTilesetName.TabIndex = 0;
            this.lblTilesetName.Text = "Tileset Name:";
            // 
            // txtTilesetName
            // 
            this.txtTilesetName.Location = new System.Drawing.Point(155, 5);
            this.txtTilesetName.Name = "txtTilesetName";
            this.txtTilesetName.Size = new System.Drawing.Size(100, 20);
            this.txtTilesetName.TabIndex = 1;
            // 
            // lblTilesetImageName
            // 
            this.lblTilesetImageName.AutoSize = true;
            this.lblTilesetImageName.Location = new System.Drawing.Point(22, 39);
            this.lblTilesetImageName.Name = "lblTilesetImageName";
            this.lblTilesetImageName.Size = new System.Drawing.Size(104, 13);
            this.lblTilesetImageName.TabIndex = 2;
            this.lblTilesetImageName.Text = "Tileset Image Name:";
            // 
            // txtTilesetImage
            // 
            this.txtTilesetImage.Enabled = false;
            this.txtTilesetImage.Location = new System.Drawing.Point(155, 34);
            this.txtTilesetImage.Name = "txtTilesetImage";
            this.txtTilesetImage.Size = new System.Drawing.Size(100, 20);
            this.txtTilesetImage.TabIndex = 3;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(261, 34);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(28, 23);
            this.btnSelectImage.TabIndex = 4;
            this.btnSelectImage.Text = "...";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            // 
            // lblTileWidth
            // 
            this.lblTileWidth.AutoSize = true;
            this.lblTileWidth.Location = new System.Drawing.Point(68, 69);
            this.lblTileWidth.Name = "lblTileWidth";
            this.lblTileWidth.Size = new System.Drawing.Size(58, 13);
            this.lblTileWidth.TabIndex = 5;
            this.lblTileWidth.Text = "Tile Width:";
            // 
            // mtbTileWidth
            // 
            this.mtbTileWidth.Location = new System.Drawing.Point(155, 62);
            this.mtbTileWidth.Mask = "000";
            this.mtbTileWidth.Name = "mtbTileWidth";
            this.mtbTileWidth.Size = new System.Drawing.Size(32, 20);
            this.mtbTileWidth.TabIndex = 6;
            // 
            // lblTileHeight
            // 
            this.lblTileHeight.AutoSize = true;
            this.lblTileHeight.Location = new System.Drawing.Point(65, 97);
            this.lblTileHeight.Name = "lblTileHeight";
            this.lblTileHeight.Size = new System.Drawing.Size(61, 13);
            this.lblTileHeight.TabIndex = 7;
            this.lblTileHeight.Text = "Tile Height:";
            // 
            // mtbTileHeight
            // 
            this.mtbTileHeight.Location = new System.Drawing.Point(155, 90);
            this.mtbTileHeight.Mask = "000";
            this.mtbTileHeight.Name = "mtbTileHeight";
            this.mtbTileHeight.Size = new System.Drawing.Size(34, 20);
            this.mtbTileHeight.TabIndex = 8;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(57, 116);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(145, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormNewTileset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 154);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.mtbTileHeight);
            this.Controls.Add(this.lblTileHeight);
            this.Controls.Add(this.mtbTileWidth);
            this.Controls.Add(this.lblTileWidth);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.txtTilesetImage);
            this.Controls.Add(this.lblTilesetImageName);
            this.Controls.Add(this.txtTilesetName);
            this.Controls.Add(this.lblTilesetName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormNewTileset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Tileset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTilesetName;
        private System.Windows.Forms.TextBox txtTilesetName;
        private System.Windows.Forms.Label lblTilesetImageName;
        private System.Windows.Forms.TextBox txtTilesetImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Label lblTileWidth;
        private System.Windows.Forms.MaskedTextBox mtbTileWidth;
        private System.Windows.Forms.Label lblTileHeight;
        private System.Windows.Forms.MaskedTextBox mtbTileHeight;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}