using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace QrSystem1
{
    public partial class HomeownerAccount : Form
    {
        public HomeownerAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Createnewaccount frm = new Createnewaccount();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close(); 
            Createnewaccount frm = new Createnewaccount();
            frm.Show();
        }

        private void NameText_Enter(object sender, EventArgs e)
        {
            if (NameText.Text == "Full Name")
            {
                NameText.Text = "";

                NameText.ForeColor = Color.Black;
            }


        }

        private void NameText_Leave(object sender, EventArgs e)
        {
            if (NameText.Text.Trim().Length == 0)
            {
                NameText.Text = "Full Name";

                NameText.ForeColor = Color.Silver;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Blk No.")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                textBox1.Text = "Blk No.";

                textBox1.ForeColor = Color.Silver;
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Lot No.")
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.Black;
            }
        }
        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                textBox2.Text = "Lot No.";

                textBox2.ForeColor = Color.Silver;
            }
        }

        

        private void ContactText_Enter(object sender, EventArgs e)
        {
            if (ContactText.Text == "Contact No.")
            {
                ContactText.Text = "";

                ContactText.ForeColor = Color.Black;
            }
        }

        private void ContactText_Leave(object sender, EventArgs e)
        {
            if (ContactText.Text.Trim().Length == 0)
            {
                ContactText.Text = "Contact No.";

                ContactText.ForeColor = Color.Silver;
            }
        }

        public string conString = "Data Source=DESKTOP-RVS1I23\\SQLEXPRESS;Initial Catalog=QrSystem;Integrated Security=True";
        private void button2_Click(object sender, EventArgs e)
        {
            if (!(NameText.Text.Equals("Full Name") || textBox1.Text.Equals("Blk No.") || textBox2.Text.Equals("Lot No.") || ContactText.Text.Equals("Contact No.")))
            {
                QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                var Mydata = NameText.Text;
                var Mydata1 = textBox1.Text; //block no
                var Mydata2 = textBox2.Text; //lot no
                var Mydata3 = ContactText.Text;
                
                var Mydata4 = Mydata + "," + Mydata1 + "," + Mydata2 + "," + Mydata3;
                var Mydata5 = QG.CreateQrCode(Mydata4, QRCoder.QRCodeGenerator.ECCLevel.H);
                var code = new QRCoder.QRCode(Mydata5);
                pictureBox1.Image = code.GetGraphic(3);

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into HO_Account(ID, Name, Block_Number, Lot_Number, Contact_Number) values('" + "','" + NameText.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + ContactText.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Added");
                }

            }
            else if (NameText.Text.Equals("Full Name") || textBox1.Text.Equals("Blk No.") || textBox2.Text.Equals("Lot No.") || ContactText.Text.Equals("Contact No."))
            {
                MessageBox.Show("Please fill up empty form/s.");
            }

            
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        

        
    }
}
