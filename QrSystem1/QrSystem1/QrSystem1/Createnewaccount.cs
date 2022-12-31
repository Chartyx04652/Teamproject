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
    public partial class Createnewaccount : Form
    {
        public Createnewaccount()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeownerAccount ss = new HomeownerAccount();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            VisitorsAccount ss = new VisitorsAccount();
            ss.Show();
        }
    }
}
