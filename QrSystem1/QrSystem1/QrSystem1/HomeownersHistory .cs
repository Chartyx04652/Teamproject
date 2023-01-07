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

        
    }
}
