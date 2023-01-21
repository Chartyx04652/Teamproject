using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

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
            
            // s
        }

        //private void homeownerAccountBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        //{
        //    BindGrid();
        //}

        //public void BindGrid()
        //{
        //    this.Validate();
        //    this.homeownerAccountBindingSource.EndEdit();
        //    this.tableAdapterManager.UpdateAll(this.userAccountDataSet1);
        //}

        //private void homeownerAccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
            
        //}
        
        //private void homeownerAccountDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (MessageBox.Show("Are you sure to delete?", "Delete record", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        string Name = homeownerAccountDataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
        //        connectionString = ConfigurationManager.ConnectionStrings["QrSystem1.Properties.Settings.UserAccountConnectionString"].ConnectionString;
        //        connection = new SqlConnection(connectionString);
        //        connection.Open();
        //        SqlCommand com = new SqlCommand("Delete homeownerHistory where Name = '" + Name + "'", connection);
        //        com.ExecuteNonQuery();
        //        MessageBox.Show("Successfully Deleted!");
        //        connection.Close();
        //        BindGrid();
        //    }
        //}

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
            //TextboxFilter();
        //}
        private void PopulatehomeownerAccount()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand com = new SqlCommand("select * from homeownerAccount", connection))

            {
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
            }

        }
        //private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //if (e.KeyCode == Keys.Enter)
        //{
        // using (connection = new SqlConnection(connectionString))
        //  using (SqlCommand com = new SqlCommand("select * from homeownerAccount where Name = '" + textBox1.Text + "'", connection))

        //  {
        //      connection.Open();
        //      SqlDataReader reader = com.ExecuteReader();
        //  }

        //}
        // }

        //private void TextboxFilter()
        //{
          //  if (e.KeyCode == Keys.Enter)
            //{
              //  if (MessageBox.Show("Are you sure you want to delete this account?", "Delete account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                  //  String query = $"select * from homeownerAccount where Name = '{textBox1.Text}'";
                    //using (connection = new SqlConnection(connectionString))
                   // using (SqlCommand cmd = new SqlCommand(query, connection))
                    //{
                      //  connection.Open();
                        //SqlDataReader reader = cmd.ExecuteReader();
                     //   if (!reader.Read())
                       // {
                      //      MessageBox.Show("Account does not exist.");
                        //}
                        //else
                        //{
                          //  String query1 = $"delete from homeownerAccount where Name = '{textBox1.Text}'";
                            //using (connection = new SqlConnection(connectionString))
                        //    using (SqlCommand cmd1 = new SqlCommand(query1, connection))
                          //  {
                            //    connection.Open();
                              //  cmd1.ExecuteNonQuery();
                       //         MessageBox.Show("Account Deleted.");
                         //       textBox1.Text = null;
                           //     textBox1.Visible = false;
                             //   adapter = new SqlDataAdapter(@"select Name, blockNo, lotNo, contactNo from homeownerAccount", connection);
                      //          datatable = new DataTable();
                        //        adapter.Fill(datatable);
                           //     homeownerAccountDataGridView.DataSource = datatable;
                          //  }
                 //       }
                   //     PopulatehomeownerAccount();
            //        }
              //  }
        //    }
          //  using (connection = new SqlConnection(connectionString))
        //    using (SqlCommand com = new SqlCommand("select * from homeownerAccount where Name = '"+textBox1.Text+"'", connection))

          //  {
            //    connection.Open();
          //      SqlDataReader reader = com.ExecuteReader();
         //   }

       // }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            datatable = new DataTable();
            adapter = new SqlDataAdapter("select * from homeownerAccount where [Name] like '"+txtSearch.Text+"%'", connection);
            adapter.Fill(datatable);
            homeownerAccountDataGridView.DataSource = datatable;
        }
    }
}   
