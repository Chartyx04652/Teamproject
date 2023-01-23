using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSystem1
{
    public partial class VisitorsHistory : Form
    {
        String connectionString;
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable datatable;
        public VisitorsHistory()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QrSystem1.Properties.Settings.UserAccountConnectionString"].ConnectionString;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ListofAccount frm = new ListofAccount();
            frm.Show();
        }

        private void visitorAccountBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.visitorAccountBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.userAccountDataSet1);

        }

        private void VisitorsHistory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userAccountDataSet2.visitorAccount' table. You can move, or remove it, as needed.
            this.visitorAccountTableAdapter1.Fill(this.userAccountDataSet2.visitorAccount);
            // TODO: This line of code loads data into the 'userAccountDataSet1.visitorAccount' table. You can move, or remove it, as needed.
            this.visitorAccountTableAdapter.Fill(this.userAccountDataSet1.visitorAccount);
            PopulatevisitorAccount();
        }
        private void PopulatevisitorAccount()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand com = new SqlCommand("select * from visitorAccount", connection))

            {
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            datatable = new DataTable();
            adapter = new SqlDataAdapter("select * from visitorAccount where [Name] like '" + txtSearch.Text + "%'", connection);
            adapter.Fill(datatable);
            visitorAccountDataGridView.DataSource = datatable;
        }

        private void visitorAccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to create a QRCode?", "QRCode generate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.visitorAccountDataGridView.Rows[e.RowIndex];

                    QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                    var Mydata = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                    var Mydata1 = row.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                    var Mydata2 = Mydata + "," + Mydata1;
                    var Mydata3 = QG.CreateQrCode(Mydata2, QRCoder.QRCodeGenerator.ECCLevel.H);
                    var code = new QRCoder.QRCode(Mydata3);
                    //pictureBox1.Image = code.GetGraphic(3);

                    String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    code.GetGraphic(3).Save(path + "\\" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg", ImageFormat.Jpeg);

                    MessageBox.Show("QRCode successfully generated.");
                }
            }
        }
    }
}
