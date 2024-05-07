using System;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login home = new Login();
            home.Show();
            this.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            AccNumlbl.Text = "Broj racuna: " + Login.AccNumber;
        }

        private void Balance_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            bal.Show();
            this.Hide();
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Deposit_Click(object sender, EventArgs e)
        {
            Deposit depo = new Deposit();
            depo.Show();
            this.Close();
        }

        private void ChangePin_Click(object sender, EventArgs e)
        {
            ChangePin cp = new ChangePin();
            cp.Show();
            this.Close();
        }

        private void Withdraw_Click(object sender, EventArgs e)
        {
            Withdraw wtd = new Withdraw();
            wtd.Show();
            this.Close();
        }


        private void MiniStatement_Click(object sender, EventArgs e)
        {
            MiniStatement ms = new MiniStatement();
            ms.Show();
            this.Close();
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            Transfer tr = new Transfer();
            tr.Show();
            this.Close();
        }
    }
}
