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
    public partial class Deposit : Form
    {
        string curr;
        public Deposit()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(Connection.db);
        private void addTransaction() {
            int TrType = 1;
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','"+Login.AccNumber + "','" + TrType + "','" +DepoAmttb.Text+"','" +DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getcurrency()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select CurrencyTbl.Currency from CurrencyTbl inner join AccountTbl on CurrencyTbl.Id=AccountTbl.Currency where AccNum='" + Login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            curr = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("receiptD", 600, 210);
           
            if (DepoAmttb.Text=="" || Convert.ToInt32(DepoAmttb.Text) <= 0)
            {
                MessageBox.Show("Unesite ispravnu vrednost uloga");
            }
            else
            {
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                int newBalance = oldBalance + Convert.ToInt32(DepoAmttb.Text);
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where Accnum='" + Login.AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Uspesan depozit");
                    Con.Close();
                    addTransaction();
                    Home home = new Home();
                    home.Show();
                    this.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
        int oldBalance;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldBalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void Deposit_Load(object sender, EventArgs e)
        {
            getbalance();
            getcurrency();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Bankomat", new Font("Averia", 14, FontStyle.Bold), Brushes.Red, new Point(240, 20));
            e.Graphics.DrawString("Uplate i isplate sirom Srbije", new Font("Averia", 8, FontStyle.Italic), Brushes.DarkViolet, new Point(220, 40));
            e.Graphics.DrawString("__________________________________________________________________________________________________________", new Font("Averia", 10, FontStyle.Bold), Brushes.Black, new Point(0, 50));
            e.Graphics.DrawString("Broj racuna", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(26, 80));
            e.Graphics.DrawString(Login.AccNumber, new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, 100));
            e.Graphics.DrawString("Tip transakcije", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(450, 80));
            e.Graphics.DrawString("Uplata", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Blue, new Point(450, 100));
            e.Graphics.DrawString("Iznos", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(26, 140));
            e.Graphics.DrawString(DepoAmttb.Text + " " + curr, new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, 160));
            e.Graphics.DrawString("Datum", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(450, 140));
            e.Graphics.DrawString(DateTime.Now.ToString(), new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Blue, new Point(450, 160));
            e.Graphics.DrawString("__________________________________________________________________________________________________________", new Font("Averia", 10, FontStyle.Bold), Brushes.Black, new Point(0, 170));
            e.Graphics.DrawString("Transakcija izvrsena preko MojaBanka", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(10, 190));
        }
    }
}
