using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void MakeAccount_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(Connection.db);
        public static String AccNumber;
        private void Login_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AccountTbl where AccNum='" + AccNumtb.Text + "' and PIN=" + Pintb.Text + "", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                AccNumber = AccNumtb.Text;
                Home home = new Home();
                home.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Neispravan broj racuna ili PIN");
            }
            Con.Close();
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
