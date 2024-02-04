using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain(string username)
        {
            this.username = username;
            InitializeComponent();
        }
        private string username;

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text += username; ;

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
