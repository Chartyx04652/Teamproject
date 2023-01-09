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
    public partial class HistoryPageofAccount : Form
    {
        public HistoryPageofAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
