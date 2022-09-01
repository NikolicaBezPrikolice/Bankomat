using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Close();
            home.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AccNumberlbl_Click(object sender, EventArgs e)
        {
        }
        SqlConnection Con = new SqlConnection(Connection.db);
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='"+AccNumberlbl.Text+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sda = new SqlDataAdapter("select CurrencyTbl.Currency from CurrencyTbl inner join AccountTbl on CurrencyTbl.Id=AccountTbl.Currency where AccNum='" + AccNumberlbl.Text + "'", Con);
            sda.Fill(dt);
            Balancelbl.Text = dt.Rows[0][0].ToString()+"   "+ dt.Rows[1][1].ToString();
            Con.Close();
        }
        private void Balance_Load(object sender, EventArgs e)
        {
            AccNumberlbl.Text = Login.AccNumber;
            getbalance();
        }
    }
}
