using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class Account : Form
    {
        SqlConnection Con = new SqlConnection(Connection.db);
        string edu1;
        string cur;
        public Account()
        {
            InitializeComponent();
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private void Auto()
        {
            AccNumtb.Text = "" + GetUniqueKey(5);
        }

        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nikola\Documents\BankomatDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNumtb.Text == "" || Pintb.Text == "" || AccNametb.Text == "" || FaNametb.Text == "" || Addresstb.Text == "" || Phonetb.Text == "" || occupationtb.Text == "")
            {
                MessageBox.Show("Popunite sva polja");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AccountTbl values('" + AccNumtb.Text + "','" + AccNametb.Text + "','" + FaNametb.Text + "','" + dobdate.Value + "','" + Phonetb.Text + "','" + Addresstb.Text + "','" + edu1 + "','" + occupationtb.Text + "'," + Pintb.Text + "," + bal + ",'" + cur + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Uspesno kreiran nalog");
                    Con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BackToPreviousPage_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            Auto();
            AccNumtb.Enabled = false;
        }

        private void Educationcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select Id from EducationTbl where Education='" + educationcb.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            edu1 = dt.Rows[0][0].ToString();
        }

        private void Currencycb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select Id from CurrencyTbl where Currency='" + Currencycb.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cur = dt.Rows[0][0].ToString();
        }
    }
}
