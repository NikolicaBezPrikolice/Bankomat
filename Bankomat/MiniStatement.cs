using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class MiniStatement : Form
    {
        public MiniStatement()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(Connection.db);
        private void PopulateAll()
        {
            Con.Open();
            string query = "select * from TransactionTbl where Sender='" + Login.AccNumber + "' or Receiver='" + Login.AccNumber + "'";
            string query1 = "select t1.Name as 'Ime posiljaoca', t1.FaName as 'Prezime primaoca', t2.Name as 'Ime primaoca', t2.FaName as 'Prezime posiljaoca', TransactionTypeTbl.Type as 'Tip transakcije', Amount as Svota,CurrencyTbl.Currency as valuta, TDate as Datum " +
                "from TransactionTbl " +
                "INNER JOIN AccountTbl as t1 ON (TransactionTbl.Sender=t1.AccNum) " +
                "INNER JOIN AccountTbl as t2 ON (TransactionTbl.Receiver=t2.AccNum) " +
                "INNER JOIN TransactionTypeTbl on (TransactionTypeTbl.Id=TransactionTbl.Type)" +
                "INNER JOIN CurrencyTbl on(t1.Currency=CurrencyTbl.Id)" +
                "where Sender='" + Login.AccNumber + "' or Receiver='" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query1, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MiniStatementdgv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void PopulateType(int Ttype)
        {
            Con.Open();
            string query = "select t1.Name as 'Ime posiljaoca', t1.FaName as 'Prezime primaoca', t2.Name as 'Ime primaoca', t2.FaName as 'Prezime posiljaoca', TransactionTypeTbl.Type as 'Tip transakcije', Amount as Svota,CurrencyTbl.Currency as valuta, TDate as Datum " +
                "from TransactionTbl " +
                "INNER JOIN AccountTbl as t1 ON (TransactionTbl.Sender=t1.AccNum) " +
                "INNER JOIN AccountTbl as t2 ON (TransactionTbl.Receiver=t2.AccNum) " +
                "INNER JOIN TransactionTypeTbl on (TransactionTypeTbl.Id=TransactionTbl.Type)" +
                "INNER JOIN CurrencyTbl on(t1.Currency=CurrencyTbl.Id)" +
                "where (Sender='" + Login.AccNumber + "' or Receiver='" + Login.AccNumber + "') and TransactionTbl.Type='" + Ttype + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MiniStatementdgv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void MiniStatement_Load(object sender, EventArgs e)
        {
            PopulateAll();
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

        private void Educationcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typecb.SelectedItem.ToString() == "Uplata")
            {
                PopulateType(1);
            }
            else if (typecb.SelectedItem.ToString() == "Isplata")
            {
                PopulateType(2);
            }
            if (typecb.SelectedItem.ToString() == "Transfer")
            {
                PopulateType(3);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (MiniStatementdgv.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Result.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {

                            ErrorMessage = true;
                            MessageBox.Show("Unable to wride data in disk" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(MiniStatementdgv.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in MiniStatementdgv.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in MiniStatementdgv.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value.ToString());
                                }
                            }


                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)
                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");

            }
        }


    }
}
