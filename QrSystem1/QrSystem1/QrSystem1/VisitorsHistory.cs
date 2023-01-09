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
    public partial class VisitorsHistory : Form
    {
        public VisitorsHistory()
        {
            InitializeComponent();
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

        }
    }
}
