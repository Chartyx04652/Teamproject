using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace QrSystem1
{
    public partial class HistoryPageAccount : Form
    {
        String connectionString;
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable datatable;
        public HistoryPageAccount()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QrSystem1.Properties.Settings.UserAccountConnectionString"].ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void homeownerHistoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.homeownerHistoryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.userAccountDataSet1);

        }

        private void HistoryPageAccount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userAccountDataSet1.visitorHistory' table. You can move, or remove it, as needed.
            this.visitorHistoryTableAdapter.Fill(this.userAccountDataSet1.visitorHistory);
            // TODO: This line of code loads data into the 'userAccountDataSet1.homeownerHistory' table. You can move, or remove it, as needed.
            this.homeownerHistoryTableAdapter.Fill(this.userAccountDataSet1.homeownerHistory);






        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            datatable = new DataTable();
            adapter = new SqlDataAdapter("select * from homeownerHistory where [Name] like '%" + textBox1.Text + "%'", connection);
            adapter.Fill(datatable);
            homeownerHistoryDataGridView.DataSource = datatable;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            datatable = new DataTable();
            adapter = new SqlDataAdapter("select * from homeownerHistory where [dateAndTime] like '%" + textBox2.Text + "%'", connection);
            adapter.Fill(datatable);
            homeownerHistoryDataGridView.DataSource = datatable;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            datatable = new DataTable();
            adapter = new SqlDataAdapter("select * from visitorHistory where [Name] like '%" + textBox3.Text + "%'", connection);
            adapter.Fill(datatable);
            visitorHistoryDataGridView.DataSource = datatable;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            datatable = new DataTable();
            adapter = new SqlDataAdapter("select * from visitorHistory where [dateAndTime] like '%" + textBox4.Text + "%'", connection);
            adapter.Fill(datatable);
            visitorHistoryDataGridView.DataSource = datatable;
        }
    }
}

        