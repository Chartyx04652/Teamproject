using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if (textBox1.Visible == true)
        //    {
        //        textBox1.Visible = false;
        //    }
        //    else
        //    {
        //        textBox1.Visible = true;
        //    }

        //}

        //private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (MessageBox.Show("Are you sure you want to delete this account?", "Delete account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            String query = $"select * from visitorAccount where Name = '{textBox1.Text}'";
        //            using (connection = new SqlConnection(connectionString))
        //            using (SqlCommand cmd = new SqlCommand(query, connection))
        //            {
        //                connection.Open();
        //                SqlDataReader reader = cmd.ExecuteReader();
        //                if (!reader.Read())
        //                {
        //                    MessageBox.Show("Account does not exist.");
        //                }
        //                else
        //                {
        //                    String query1 = $"delete from visitorAccount where Name = '{textBox1.Text}'";
        //                    using (connection = new SqlConnection(connectionString))
        //                    using (SqlCommand cmd1 = new SqlCommand(query1, connection))
        //                    {
        //                        connection.Open();
        //                        cmd1.ExecuteNonQuery();
        //                        MessageBox.Show("Account Deleted.");
        //                        textBox1.Text = null;
        //                        textBox1.Visible = false;
        //                        adapter = new SqlDataAdapter(@"select Name, purposeOfVisit from visitorAccount", connection);
        //                        datatable = new DataTable();
        //                        adapter.Fill(datatable);
        //                        visitorAccountDataGridView.DataSource = datatable;
        //                    }
        //                }
        //            PopulatevisitorAccount();
        //            }
        //        }
        //    }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            datatable = new DataTable();
            adapter = new SqlDataAdapter("select * from visitorAccount where [Name] like '" + txtSearch.Text + "%'", connection);
            adapter.Fill(datatable);
            visitorAccountDataGridView.DataSource = datatable;
        }
    }
}
