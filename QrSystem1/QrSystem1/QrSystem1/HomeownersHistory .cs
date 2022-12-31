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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HomeownersHistory_SizeChanged(object sender, EventArgs e)
        {

        }

        private void HomeownersHistory_Shown(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(
                new object[]
                {
                    "Vincent Willioamson",
                    "3",
                    "9",
                    "09231231231",
                    
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "Darren Dave Macrol",
                    "232",
                    "P. Buhangin",
                    "012372321"
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "Vincent Willioamson",
                    
                    "Sta. Maria",
                    "0123724123"
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "Vincent Willioamson",
                   
                    "Bocaue",
                    "091231232"
                }
                );

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ExistingAcccount frm = new ExistingAcccount();
            frm.Show();
        }
    }
}
