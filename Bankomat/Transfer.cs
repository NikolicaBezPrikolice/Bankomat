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
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(Connection.db);
        int currS;
        int currR;
        double rate;
        private void addTransaction()
        {
            string TrType = "3";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" +receivertb.Text + "','" + TrType + "','" + amounttb.Text + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int oldbalanceR;
        int oldbalanceS;
        string check="";
        private void getbalance()
        {
            Con.Open();            
            SqlDataAdapter sdaR = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + receivertb.Text + "'", Con);
            SqlDataAdapter sdaS = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sdaR.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                check = "Nepostojeci racun";
            }
            else
            {
                check = "";
                sdaS.Fill(dt);
                oldbalanceR = Convert.ToInt32(dt.Rows[0][0]);
                oldbalanceS = Convert.ToInt32(dt.Rows[1][0]);
            }
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("receiptD", 600, 210);
           
            if (receivertb.Text == "" || amounttb.Text=="")
            {
                MessageBox.Show("Popunite sva polja");
            }
            else
            {
                getbalance();

                if (check == "")
                {
                    if (oldbalanceS < Convert.ToInt32(amounttb.Text))
                    {
                        MessageBox.Show("Prekoracenje");
                    }
                    else
                    {
                        if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                        {
                            printDocument1.Print();
                        }
                        Con.Open();
                        SqlDataAdapter sdaCR = new SqlDataAdapter("select Currency from AccountTbl where AccNum='" + receivertb.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sdaCR.Fill(dt);
                        currR = Convert.ToInt32(dt.Rows[0][0]);
                        SqlDataAdapter sdaR = new SqlDataAdapter("select rate from ExchangeTbl where first='" + currS + "'and second='" + currR + "'", Con);
                        sdaR.Fill(dt);
                        rate = Convert.ToDouble(dt.Rows[1][1]);
                        Con.Close();
                        double newBalanceR = oldbalanceR + Convert.ToInt32(amounttb.Text) * rate;
                        int newBalanceS = oldbalanceS - Convert.ToInt32(amounttb.Text);
                        try
                        {
                            Con.Open();
                            string query = "update AccountTbl set Balance=" + newBalanceR + " where Accnum='" + receivertb.Text + "'";
                            string query1 = "update AccountTbl set Balance=" + newBalanceS + " where Accnum='" + Login.AccNumber + "'";
                            SqlCommand cmd = new SqlCommand(query, Con);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand(query1, Con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Uspesan Transfer");
                            Con.Close();
                            addTransaction();
                            Home home = new Home();
                            home.Show();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(check);
                }
            }
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sdaCS = new SqlDataAdapter("select Currency from AccountTbl where AccNum='" + Login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sdaCS.Fill(dt);
            currS = Convert.ToInt32(dt.Rows[0][0]);
            Con.Close();
        }

        private void receivertb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Close();
            home.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Bankomat", new Font("Averia", 14, FontStyle.Bold), Brushes.Red, new Point(240, 20));
            e.Graphics.DrawString("Uplate i isplate sirom Srbije", new Font("Averia", 8, FontStyle.Italic), Brushes.DarkViolet, new Point(220, 40));
            e.Graphics.DrawString("__________________________________________________________________________________________________________", new Font("Averia", 10, FontStyle.Bold), Brushes.Black, new Point(0, 50));
            e.Graphics.DrawString("Posiljalac", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(26, 80));
            e.Graphics.DrawString(Login.AccNumber, new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, 100));
            e.Graphics.DrawString("Primalac", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(450, 80));
            e.Graphics.DrawString(receivertb.Text, new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Blue, new Point(450, 100));
            e.Graphics.DrawString("Iznos", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(26, 140));
            e.Graphics.DrawString(amounttb.Text, new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, 160));
            e.Graphics.DrawString("Datum", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(450, 140));
            e.Graphics.DrawString(DateTime.Now.ToString(), new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Blue, new Point(450, 160));
            e.Graphics.DrawString("__________________________________________________________________________________________________________", new Font("Averia", 10, FontStyle.Bold), Brushes.Black, new Point(0, 170));
            e.Graphics.DrawString("Transakcija izvrsena preko MojaBanka", new Font("Century Gorhic", 8, FontStyle.Bold), Brushes.Black, new Point(10, 190));
        }
    }
}
