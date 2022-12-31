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
                NameText1.Text = " ";

                NameText1.ForeColor = Color.Black;
            }
        }

        private void NameText1_Leave(object sender, EventArgs e)
        {
            if (NameText1.Text == " ")
            {
                NameText1.Text = "Full Name";

                NameText1.ForeColor = Color.Silver;
            }
        }

        private void PurposeOfVisit_Enter(object sender, EventArgs e)
        {
            if (PurposeOfVisit.Text == "Purpose of Visit")
            {
                PurposeOfVisit.Text = " ";

                PurposeOfVisit.ForeColor = Color.Black;
            }
        }

        private void PurposeOfVisit_Leave(object sender, EventArgs e)
        {
            if (PurposeOfVisit.Text == " ")
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
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var Mydata = QG.CreateQrCode(NameText1.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(Mydata);
            pictureimage1.Image = code.GetGraphic(3);
        }
    }
}
