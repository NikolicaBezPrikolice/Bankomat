using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login home = new Login();
            home.Show();
            this.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            AccNumlbl.Text = "Broj racuna: " + Login.AccNumber;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            bal.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deposit depo = new Deposit();
            depo.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePin cp = new ChangePin();
            cp.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Withdraw wtd = new Withdraw();
            wtd.Show();
            this.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            MiniStatement ms = new MiniStatement();
            ms.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Transfer tr = new Transfer();
            tr.Show();
            this.Close();
        }

        private void AccNumlbl_Click(object sender, EventArgs e)
        {

        }
    }
}
