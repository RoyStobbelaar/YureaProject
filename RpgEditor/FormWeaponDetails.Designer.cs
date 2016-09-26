namespace RpgEditor
{
    partial class FormWeaponDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.txtWeight = new System.Windows.Forms.NumericUpDown();
            this.txtHands = new System.Windows.Forms.ComboBox();
            this.txtAttackValue = new System.Windows.Forms.MaskedTextBox();
            this.txtAttackModifier = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbClasses = new System.Windows.Forms.ListBox();
            this.lbAllowedClasses = new System.Windows.Forms.ListBox();
            this.btnAllowed = new System.Windows.Forms.Button();
            this.btnRemoveAllowed = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDieType = new System.Windows.Forms.Label();
            this.txtDieType = new System.Windows.Forms.ComboBox();
            this.nudNumberOfDice = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfDice = new System.Windows.Forms.Label();
            this.lblDamageModifier = new System.Windows.Forms.Label();
            this.txtDamageModifier = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfDice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Weight:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hands:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Attack Value:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Attack Modifier:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(127, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 20);
            this.txtName.TabIndex = 9;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(127, 49);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(137, 20);
            this.txtType.TabIndex = 10;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(127, 75);
            this.txtPrice.Mask = "00000";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(137, 20);
            this.txtPrice.TabIndex = 11;
            // 
            // txtWeight
            // 
            this.txtWeight.DecimalPlaces = 2;
            this.txtWeight.Location = new System.Drawing.Point(127, 101);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(137, 20);
            this.txtWeight.TabIndex = 12;
            // 
            // txtHands
            // 
            this.txtHands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtHands.FormattingEnabled = true;
            this.txtHands.Location = new System.Drawing.Point(127, 127);
            this.txtHands.Name = "txtHands";
            this.txtHands.Size = new System.Drawing.Size(137, 21);
            this.txtHands.TabIndex = 13;
            // 
            // txtAttackValue
            // 
            this.txtAttackValue.Location = new System.Drawing.Point(127, 154);
            this.txtAttackValue.Mask = "00";
            this.txtAttackValue.Name = "txtAttackValue";
            this.txtAttackValue.Size = new System.Drawing.Size(137, 20);
            this.txtAttackValue.TabIndex = 14;
            // 
            // txtAttackModifier
            // 
            this.txtAttackModifier.Location = new System.Drawing.Point(127, 180);
            this.txtAttackModifier.Mask = "00";
            this.txtAttackModifier.Name = "txtAttackModifier";
            this.txtAttackModifier.Size = new System.Drawing.Size(137, 20);
            this.txtAttackModifier.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(281, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Character Classes:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(485, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Allowed Classes:";
            // 
            // lbClasses
            // 
            this.lbClasses.FormattingEnabled = true;
            this.lbClasses.Location = new System.Drawing.Point(284, 49);
            this.lbClasses.Name = "lbClasses";
            this.lbClasses.Size = new System.Drawing.Size(119, 199);
            this.lbClasses.TabIndex = 20;
            // 
            // lbAllowedClasses
            // 
            this.lbAllowedClasses.FormattingEnabled = true;
            this.lbAllowedClasses.Location = new System.Drawing.Point(488, 49);
            this.lbAllowedClasses.Name = "lbAllowedClasses";
            this.lbAllowedClasses.Size = new System.Drawing.Size(120, 199);
            this.lbAllowedClasses.TabIndex = 21;
            // 
            // btnAllowed
            // 
            this.btnAllowed.Location = new System.Drawing.Point(409, 92);
            this.btnAllowed.Name = "btnAllowed";
            this.btnAllowed.Size = new System.Drawing.Size(73, 23);
            this.btnAllowed.TabIndex = 22;
            this.btnAllowed.Text = ">>";
            this.btnAllowed.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAllowed
            // 
            this.btnRemoveAllowed.Location = new System.Drawing.Point(409, 122);
            this.btnRemoveAllowed.Name = "btnRemoveAllowed";
            this.btnRemoveAllowed.Size = new System.Drawing.Size(73, 23);
            this.btnRemoveAllowed.TabIndex = 23;
            this.btnRemoveAllowed.Text = "<<";
            this.btnRemoveAllowed.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(364, 259);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 24;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(451, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDieType
            // 
            this.lblDieType.AutoSize = true;
            this.lblDieType.Location = new System.Drawing.Point(68, 210);
            this.lblDieType.Name = "lblDieType";
            this.lblDieType.Size = new System.Drawing.Size(53, 13);
            this.lblDieType.TabIndex = 26;
            this.lblDieType.Text = "Die Type:";
            // 
            // txtDieType
            // 
            this.txtDieType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDieType.FormattingEnabled = true;
            this.txtDieType.Location = new System.Drawing.Point(127, 206);
            this.txtDieType.Name = "txtDieType";
            this.txtDieType.Size = new System.Drawing.Size(137, 21);
            this.txtDieType.TabIndex = 17;
            // 
            // nudNumberOfDice
            // 
            this.nudNumberOfDice.Location = new System.Drawing.Point(127, 235);
            this.nudNumberOfDice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfDice.Name = "nudNumberOfDice";
            this.nudNumberOfDice.Size = new System.Drawing.Size(137, 20);
            this.nudNumberOfDice.TabIndex = 18;
            this.nudNumberOfDice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumberOfDice
            // 
            this.lblNumberOfDice.AutoSize = true;
            this.lblNumberOfDice.Location = new System.Drawing.Point(37, 239);
            this.lblNumberOfDice.Name = "lblNumberOfDice";
            this.lblNumberOfDice.Size = new System.Drawing.Size(84, 13);
            this.lblNumberOfDice.TabIndex = 27;
            this.lblNumberOfDice.Text = "Number of Dice:";
            // 
            // lblDamageModifier
            // 
            this.lblDamageModifier.AutoSize = true;
            this.lblDamageModifier.Location = new System.Drawing.Point(31, 265);
            this.lblDamageModifier.Name = "lblDamageModifier";
            this.lblDamageModifier.Size = new System.Drawing.Size(90, 13);
            this.lblDamageModifier.TabIndex = 28;
            this.lblDamageModifier.Text = "Damage Modifier:";
            // 
            // txtDamageModifier
            // 
            this.txtDamageModifier.Location = new System.Drawing.Point(127, 261);
            this.txtDamageModifier.Mask = "0000";
            this.txtDamageModifier.Name = "txtDamageModifier";
            this.txtDamageModifier.Size = new System.Drawing.Size(137, 20);
            this.txtDamageModifier.TabIndex = 29;
            // 
            // FormWeaponDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 297);
            this.Controls.Add(this.txtDamageModifier);
            this.Controls.Add(this.lblDamageModifier);
            this.Controls.Add(this.lblNumberOfDice);
            this.Controls.Add(this.nudNumberOfDice);
            this.Controls.Add(this.txtDieType);
            this.Controls.Add(this.lblDieType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnRemoveAllowed);
            this.Controls.Add(this.btnAllowed);
            this.Controls.Add(this.lbAllowedClasses);
            this.Controls.Add(this.lbClasses);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAttackModifier);
            this.Controls.Add(this.txtAttackValue);
            this.Controls.Add(this.txtHands);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormWeaponDetails";
            this.Text = "Weapon Details";
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfDice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private System.Windows.Forms.NumericUpDown txtWeight;
        private System.Windows.Forms.ComboBox txtHands;
        private System.Windows.Forms.MaskedTextBox txtAttackValue;
        private System.Windows.Forms.MaskedTextBox txtAttackModifier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lbClasses;
        private System.Windows.Forms.ListBox lbAllowedClasses;
        private System.Windows.Forms.Button btnAllowed;
        private System.Windows.Forms.Button btnRemoveAllowed;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDieType;
        private System.Windows.Forms.ComboBox txtDieType;
        private System.Windows.Forms.NumericUpDown nudNumberOfDice;
        private System.Windows.Forms.Label lblNumberOfDice;
        private System.Windows.Forms.Label lblDamageModifier;
        private System.Windows.Forms.MaskedTextBox txtDamageModifier;
    }
}