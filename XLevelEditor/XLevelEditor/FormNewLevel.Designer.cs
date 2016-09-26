namespace XLevelEditor
{
    partial class FormNewLevel
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
            this.lblLevelName = new System.Windows.Forms.Label();
            this.txtLevelName = new System.Windows.Forms.TextBox();
            this.lblMapName = new System.Windows.Forms.Label();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.lblMapWidth = new System.Windows.Forms.Label();
            this.mtbWidth = new System.Windows.Forms.MaskedTextBox();
            this.lblMapHeight = new System.Windows.Forms.Label();
            this.mtbHeight = new System.Windows.Forms.MaskedTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLevelName
            // 
            this.lblLevelName.AutoSize = true;
            this.lblLevelName.Location = new System.Drawing.Point(13, 15);
            this.lblLevelName.Name = "lblLevelName";
            this.lblLevelName.Size = new System.Drawing.Size(67, 13);
            this.lblLevelName.TabIndex = 0;
            this.lblLevelName.Text = "Level Name:";
            // 
            // txtLevelName
            // 
            this.txtLevelName.Location = new System.Drawing.Point(106, 12);
            this.txtLevelName.Name = "txtLevelName";
            this.txtLevelName.Size = new System.Drawing.Size(100, 20);
            this.txtLevelName.TabIndex = 1;
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(17, 42);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(62, 13);
            this.lblMapName.TabIndex = 2;
            this.lblMapName.Text = "Map Name:";
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(106, 42);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(100, 20);
            this.txtMapName.TabIndex = 3;
            // 
            // lblMapWidth
            // 
            this.lblMapWidth.AutoSize = true;
            this.lblMapWidth.Location = new System.Drawing.Point(21, 75);
            this.lblMapWidth.Name = "lblMapWidth";
            this.lblMapWidth.Size = new System.Drawing.Size(62, 13);
            this.lblMapWidth.TabIndex = 4;
            this.lblMapWidth.Text = "Map Width:";
            // 
            // mtbWidth
            // 
            this.mtbWidth.Location = new System.Drawing.Point(106, 72);
            this.mtbWidth.Mask = "0000";
            this.mtbWidth.Name = "mtbWidth";
            this.mtbWidth.Size = new System.Drawing.Size(45, 20);
            this.mtbWidth.TabIndex = 5;
            // 
            // lblMapHeight
            // 
            this.lblMapHeight.AutoSize = true;
            this.lblMapHeight.Location = new System.Drawing.Point(13, 106);
            this.lblMapHeight.Name = "lblMapHeight";
            this.lblMapHeight.Size = new System.Drawing.Size(65, 13);
            this.lblMapHeight.TabIndex = 6;
            this.lblMapHeight.Text = "Map Height:";
            // 
            // mtbHeight
            // 
            this.mtbHeight.Location = new System.Drawing.Point(106, 103);
            this.mtbHeight.Mask = "0000";
            this.mtbHeight.Name = "mtbHeight";
            this.mtbHeight.Size = new System.Drawing.Size(45, 20);
            this.mtbHeight.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(13, 142);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(106, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormNewLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 171);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.mtbHeight);
            this.Controls.Add(this.lblMapHeight);
            this.Controls.Add(this.mtbWidth);
            this.Controls.Add(this.lblMapWidth);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.txtLevelName);
            this.Controls.Add(this.lblLevelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormNewLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Level";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLevelName;
        private System.Windows.Forms.TextBox txtLevelName;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Label lblMapWidth;
        private System.Windows.Forms.MaskedTextBox mtbWidth;
        private System.Windows.Forms.Label lblMapHeight;
        private System.Windows.Forms.MaskedTextBox mtbHeight;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}