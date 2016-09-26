namespace RpgEditor
{
    partial class FormShieldDetails
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnRemoveAllowed = new System.Windows.Forms.Button();
            this.btnAllowed = new System.Windows.Forms.Button();
            this.lbAllowedClasses = new System.Windows.Forms.ListBox();
            this.lbClasses = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDefenseModifier = new System.Windows.Forms.MaskedTextBox();
            this.txtDefenseValue = new System.Windows.Forms.MaskedTextBox();
            this.txtWeight = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(441, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 73;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(354, 248);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 72;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAllowed
            // 
            this.btnRemoveAllowed.Location = new System.Drawing.Point(399, 111);
            this.btnRemoveAllowed.Name = "btnRemoveAllowed";
            this.btnRemoveAllowed.Size = new System.Drawing.Size(73, 23);
            this.btnRemoveAllowed.TabIndex = 71;
            this.btnRemoveAllowed.Text = "<<";
            this.btnRemoveAllowed.UseVisualStyleBackColor = true;
            // 
            // btnAllowed
            // 
            this.btnAllowed.Location = new System.Drawing.Point(399, 81);
            this.btnAllowed.Name = "btnAllowed";
            this.btnAllowed.Size = new System.Drawing.Size(73, 23);
            this.btnAllowed.TabIndex = 70;
            this.btnAllowed.Text = ">>";
            this.btnAllowed.UseVisualStyleBackColor = true;
            // 
            // lbAllowedClasses
            // 
            this.lbAllowedClasses.FormattingEnabled = true;
            this.lbAllowedClasses.Location = new System.Drawing.Point(478, 38);
            this.lbAllowedClasses.Name = "lbAllowedClasses";
            this.lbAllowedClasses.Size = new System.Drawing.Size(120, 199);
            this.lbAllowedClasses.TabIndex = 69;
            // 
            // lbClasses
            // 
            this.lbClasses.FormattingEnabled = true;
            this.lbClasses.Location = new System.Drawing.Point(274, 38);
            this.lbClasses.Name = "lbClasses";
            this.lbClasses.Size = new System.Drawing.Size(119, 199);
            this.lbClasses.TabIndex = 68;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(475, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Allowed Classes:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 66;
            this.label10.Text = "Character Classes:";
            // 
            // txtDefenseModifier
            // 
            this.txtDefenseModifier.Location = new System.Drawing.Point(117, 142);
            this.txtDefenseModifier.Mask = "00";
            this.txtDefenseModifier.Name = "txtDefenseModifier";
            this.txtDefenseModifier.Size = new System.Drawing.Size(137, 20);
            this.txtDefenseModifier.TabIndex = 65;
            // 
            // txtDefenseValue
            // 
            this.txtDefenseValue.Location = new System.Drawing.Point(117, 116);
            this.txtDefenseValue.Mask = "00";
            this.txtDefenseValue.Name = "txtDefenseValue";
            this.txtDefenseValue.Size = new System.Drawing.Size(137, 20);
            this.txtDefenseValue.TabIndex = 64;
            // 
            // txtWeight
            // 
            this.txtWeight.DecimalPlaces = 2;
            this.txtWeight.Location = new System.Drawing.Point(117, 90);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(137, 20);
            this.txtWeight.TabIndex = 62;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(117, 64);
            this.txtPrice.Mask = "00000";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(137, 20);
            this.txtPrice.TabIndex = 61;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(117, 38);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(137, 20);
            this.txtType.TabIndex = 60;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(117, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 20);
            this.txtName.TabIndex = 59;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Defense Modifier:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Defense Value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Weight:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Name:";
            // 
            // FormShieldDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 284);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnRemoveAllowed);
            this.Controls.Add(this.btnAllowed);
            this.Controls.Add(this.lbAllowedClasses);
            this.Controls.Add(this.lbClasses);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDefenseModifier);
            this.Controls.Add(this.txtDefenseValue);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormShieldDetails";
            this.Text = "Shield Details";
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnRemoveAllowed;
        private System.Windows.Forms.Button btnAllowed;
        private System.Windows.Forms.ListBox lbAllowedClasses;
        private System.Windows.Forms.ListBox lbClasses;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtDefenseModifier;
        private System.Windows.Forms.MaskedTextBox txtDefenseValue;
        private System.Windows.Forms.NumericUpDown txtWeight;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}