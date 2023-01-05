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
    public partial class VisitorsAccount : Form
    {
        public VisitorsAccount()
        {
            InitializeComponent();
        }

        private void NameText1_Enter(object sender, EventArgs e)
        {
            if (NameText1.Text == "Full Name")
            {
                NameText1.Text = "";

                NameText1.ForeColor = Color.Black;
            }
        }

        private void NameText1_Leave(object sender, EventArgs e)
        {
            if (NameText1.Text.Trim().Length == 0)
            {
                NameText1.Text = "Full Name";

                NameText1.ForeColor = Color.Silver;
            }
        }

        private void PurposeOfVisit_Enter(object sender, EventArgs e)
        {
            if (PurposeOfVisit.Text == "Purpose of Visit")
            {
                PurposeOfVisit.Text = "";

                PurposeOfVisit.ForeColor = Color.Black;
            }
        }

        private void PurposeOfVisit_Leave(object sender, EventArgs e)
        {
            if (PurposeOfVisit.Text.Trim().Length == 0)
            {
                PurposeOfVisit.Text = "Purpose of Visit";

                PurposeOfVisit.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Createnewaccount frm = new Createnewaccount();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(NameText1.Text.Equals("Full Name") || PurposeOfVisit.Text.Equals("Purpose of Visit")))
            {
                QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                var Mydata = NameText1.Text;
                var Mydata1 = PurposeOfVisit.Text;
                var Mydata2 = NameText1.Text + "," + PurposeOfVisit.Text;
                var Mydata3 = QG.CreateQrCode(Mydata2, QRCoder.QRCodeGenerator.ECCLevel.H);
                var code = new QRCoder.QRCode(Mydata3);
                pictureimage1.Image = code.GetGraphic(3);
            }
            else if (NameText1.Text.Equals("Full Name") || PurposeOfVisit.Text.Equals("Purpose of Visit"))
            {
                MessageBox.Show("Please fill up empty form/s.");
            }
        }
    }
}
