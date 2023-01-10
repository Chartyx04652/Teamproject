using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace QrSystem1
{
    public partial class HomeownersHistory : Form
    {
        String connectionString;
        SqlConnection connection;
        public HomeownersHistory()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ListofAccount frm = new ListofAccount();
            frm.Show();
        }

        private void HomeownersHistory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userAccountDataSet1.homeownerAccount' table. You can move, or remove it, as needed.
            this.homeownerAccountTableAdapter.Fill(this.userAccountDataSet1.homeownerAccount);
            // TODO: This line of code loads data into the 'userAccountDataSet1.homeownerAccount' table. You can move, or remove it, as needed.
            
            // s
        }

        private void homeownerAccountBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public void BindGrid()
        {
            this.Validate();
            this.homeownerAccountBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.userAccountDataSet1);
        }

        private void homeownerAccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void homeownerAccountDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete?", "Delete record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string Name = homeownerAccountDataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                connectionString = ConfigurationManager.ConnectionStrings["QrSystem1.Properties.Settings.UserAccountConnectionString"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand com = new SqlCommand("Delete homeownerHistory where Name = '" + Name + "'", connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted!");
                connection.Close();
                BindGrid();
            }
        }
    }
}
