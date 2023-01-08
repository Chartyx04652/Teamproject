using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSystem1
{
    public partial class HomeownersHistory : Form
    {
        public HomeownersHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ExistingAcccount frm = new ExistingAcccount();
            frm.Show();
        }

        private void HomeownersHistory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userAccountDataSet1.homeownerAccount' table. You can move, or remove it, as needed.
            this.homeownerAccountTableAdapter1.Fill(this.userAccountDataSet1.homeownerAccount);
            // s
        }
    }
}
