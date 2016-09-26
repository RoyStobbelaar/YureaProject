using RpgLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormNewGame : Form
    {

        #region Fields & Properties

        RolePlayingGame rpg;

        public RolePlayingGame RolePlayingGame
        {
            get { return rpg; }
        }

        #endregion

        #region Constructor Region

        public FormNewGame()
        {
            InitializeComponent();
            btnOk.Click += new EventHandler(btnOk_click);
        }

        #endregion

        #region Event Region

        void btnOk_click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Enter a name and description.", "Error");
                return;
            }

            rpg = new RolePlayingGame(txtName.Text, txtDescription.Text);
            this.Close();
        }

        #endregion
    }
}