namespace RpgEditor
{
    partial class FormSkillsDetail
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbStrength = new System.Windows.Forms.RadioButton();
            this.rbDexterity = new System.Windows.Forms.RadioButton();
            this.rbCunning = new System.Windows.Forms.RadioButton();
            this.rbWillpower = new System.Windows.Forms.RadioButton();
            this.rbMagic = new System.Windows.Forms.RadioButton();
            this.rbConstitution = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbModifiers = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Skill Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(105, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 20);
            this.txtName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbConstitution);
            this.groupBox1.Controls.Add(this.rbMagic);
            this.groupBox1.Controls.Add(this.rbWillpower);
            this.groupBox1.Controls.Add(this.rbCunning);
            this.groupBox1.Controls.Add(this.rbDexterity);
            this.groupBox1.Controls.Add(this.rbStrength);
            this.groupBox1.Location = new System.Drawing.Point(42, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 180);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Primary Attribute";
            // 
            // rbStrength
            // 
            this.rbStrength.AutoSize = true;
            this.rbStrength.Checked = true;
            this.rbStrength.Location = new System.Drawing.Point(6, 30);
            this.rbStrength.Name = "rbStrength";
            this.rbStrength.Size = new System.Drawing.Size(65, 17);
            this.rbStrength.TabIndex = 0;
            this.rbStrength.TabStop = true;
            this.rbStrength.Text = "Strength";
            this.rbStrength.UseVisualStyleBackColor = true;
            // 
            // rbDexterity
            // 
            this.rbDexterity.AutoSize = true;
            this.rbDexterity.Location = new System.Drawing.Point(6, 53);
            this.rbDexterity.Name = "rbDexterity";
            this.rbDexterity.Size = new System.Drawing.Size(66, 17);
            this.rbDexterity.TabIndex = 3;
            this.rbDexterity.Text = "Dexterity";
            this.rbDexterity.UseVisualStyleBackColor = true;
            // 
            // rbCunning
            // 
            this.rbCunning.AutoSize = true;
            this.rbCunning.Location = new System.Drawing.Point(6, 76);
            this.rbCunning.Name = "rbCunning";
            this.rbCunning.Size = new System.Drawing.Size(64, 17);
            this.rbCunning.TabIndex = 3;
            this.rbCunning.Text = "Cunning";
            this.rbCunning.UseVisualStyleBackColor = true;
            // 
            // rbWillpower
            // 
            this.rbWillpower.AutoSize = true;
            this.rbWillpower.Location = new System.Drawing.Point(6, 99);
            this.rbWillpower.Name = "rbWillpower";
            this.rbWillpower.Size = new System.Drawing.Size(71, 17);
            this.rbWillpower.TabIndex = 3;
            this.rbWillpower.Text = "Willpower";
            this.rbWillpower.UseVisualStyleBackColor = true;
            // 
            // rbMagic
            // 
            this.rbMagic.AutoSize = true;
            this.rbMagic.Location = new System.Drawing.Point(6, 122);
            this.rbMagic.Name = "rbMagic";
            this.rbMagic.Size = new System.Drawing.Size(54, 17);
            this.rbMagic.TabIndex = 3;
            this.rbMagic.Text = "Magic";
            this.rbMagic.UseVisualStyleBackColor = true;
            // 
            // rbConstitution
            // 
            this.rbConstitution.AutoSize = true;
            this.rbConstitution.Location = new System.Drawing.Point(6, 145);
            this.rbConstitution.Name = "rbConstitution";
            this.rbConstitution.Size = new System.Drawing.Size(83, 17);
            this.rbConstitution.TabIndex = 3;
            this.rbConstitution.Text = "Constritution";
            this.rbConstitution.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.lbModifiers);
            this.groupBox2.Location = new System.Drawing.Point(177, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 180);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Class Modifiers";
            // 
            // lbModifiers
            // 
            this.lbModifiers.FormattingEnabled = true;
            this.lbModifiers.Location = new System.Drawing.Point(7, 20);
            this.lbModifiers.Name = "lbModifiers";
            this.lbModifiers.Size = new System.Drawing.Size(327, 108);
            this.lbModifiers.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(48, 142);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(130, 142);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(212, 142);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(173, 271);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(273, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormSkillsDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 306);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "FormSkillsDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skill";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbConstitution;
        private System.Windows.Forms.RadioButton rbMagic;
        private System.Windows.Forms.RadioButton rbWillpower;
        private System.Windows.Forms.RadioButton rbCunning;
        private System.Windows.Forms.RadioButton rbDexterity;
        private System.Windows.Forms.RadioButton rbStrength;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbModifiers;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}