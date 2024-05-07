using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class ChangePin : Form
    {
        public ChangePin()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(Connection.db);
        private void ChangePIN_Click(object sender, EventArgs e)
        {
            if (pin1tb.Text == "" || pin1tb.Text == "")
            {
                MessageBox.Show("Popunite oba polja");
            }
            else if (pin1tb.Text != pin2tb.Text)
            {
                MessageBox.Show("Unesene vrednosti se ne podudaraju");
            }
            else
            {

                try
                {
                    Con.Open();
                    string query = "update AccountTbl set PIN=" + pin1tb.Text + " where Accnum='" + Login.AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Promenili ste PIN");
                    Con.Close();
                    Login home = new Login();
                    home.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BackToPreviousPage_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
