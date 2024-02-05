using Npgsql;
using System.Data;

namespace WinFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //connect to db 
        private NpgsqlConnection conn;
        string connstring = String.Format("Server={0};Port={1};" + "User Id={2};Password={3};Database={4};", "localhost", "5432", "postgres", "m,./", "Demo");
        //private DataTable dt;
        private NpgsqlCommand cmd;
        private string sql = null;
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //this.Hide();
            // new frmMain(txtUsername.Text).Show();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    sql = @"SELECT * FROM u_login(:_username, :_password) ";
                    cmd = new NpgsqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("_username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("_password", txtPassword.Text);
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        this.Hide();
                        new frmMain(txtUsername.Text).Show();
                    }
                    else
                    {
                        MessageBox.Show("Please check your username or password", "Login fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Connection is  not open", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
     
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
        }
    }
}
