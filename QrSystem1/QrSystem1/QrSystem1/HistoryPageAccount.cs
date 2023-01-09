using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSystem1
{
    public partial class HistoryPageAccount : Form
    {
        public HistoryPageAccount()
        {
            InitializeComponent();
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
    }

}
