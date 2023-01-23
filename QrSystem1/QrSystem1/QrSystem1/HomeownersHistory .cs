using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Imaging;

namespace QrSystem1
{
    public partial class HomeownersHistory : Form
    {
        String connectionString;
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable datatable;
        public HomeownersHistory()
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

        private void HomeownersHistory_Load(object sender, EventArgs e)
        {
            PopulatehomeownerAccount();
            // TODO: This line of code loads data into the 'userAccountDataSet1.homeownerAccount' table. You can move, or remove it, as needed.
            this.homeownerAccountTableAdapter.Fill(this.userAccountDataSet1.homeownerAccount);
            // TODO: This line of code loads data into the 'userAccountDataSet1.homeownerAccount' table. You can move, or remove it, as needed.
            
            
        }

        
        private void PopulatehomeownerAccount()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand com = new SqlCommand("select * from homeownerAccount", connection))

            {
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
            }

        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            datatable = new DataTable();
            adapter = new SqlDataAdapter("select * from homeownerAccount where [Name] like '%"+txtSearch.Text+"%'", connection);
            adapter.Fill(datatable);
            homeownerAccountDataGridView.DataSource = datatable;
        }

        private void homeownerAccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to create a QRCode?", "QRCode generate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.homeownerAccountDataGridView.Rows[e.RowIndex];

                QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                var Mydata = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                var Mydata1 = row.Cells["dataGridViewTextBoxColumn4"].Value.ToString(); //block no
                var Mydata2 = row.Cells["dataGridViewTextBoxColumn5"].Value.ToString(); //lot no
                var Mydata3 = row.Cells["dataGridViewTextBoxColumn7"].Value.ToString();

                var Mydata4 = Mydata + "," + Mydata1 + "," + Mydata2 + "," + Mydata3;
                var Mydata5 = QG.CreateQrCode(Mydata4, QRCoder.QRCodeGenerator.ECCLevel.H);
                var code = new QRCoder.QRCode(Mydata5);
                //pictureBox1.Image = code.GetGraphic(3);

                String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                code.GetGraphic(3).Save(path + "\\" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg", ImageFormat.Jpeg);

                MessageBox.Show("QRCode successfully generated."); 
            }
            }

        }
    }
}   
