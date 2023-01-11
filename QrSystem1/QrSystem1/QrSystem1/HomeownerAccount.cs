using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace QrSystem1
{
    public partial class HomeownerAccount : Form
    {
        String connectionString;
        SqlConnection connection;
        public HomeownerAccount()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QrSystem1.Properties.Settings.UserAccountConnectionString"].ConnectionString;
        }
        private void HomeownerAccount_Load_1(object sender, EventArgs e)
        {
            PopulatehomeownerAccount();
        }

        private void PopulatehomeownerAccount()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand com = new SqlCommand("select * from homeownerAccount", connection))

            {
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
            }

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
        private void NameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if (Char.IsWhiteSpace(e.KeyChar)) return;
            if (e.KeyChar == '.') return;
            e.Handled = true;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void ContactText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (NameText.Text.Equals("Full Name") || textBox1.Text.Equals("Blk No.") || textBox2.Text.Equals("Lot No.") || ContactText.Text.Equals("Contact No."))
            {
                MessageBox.Show("Please fill up empty form/s.");
            }
           
            else if (ContactText.Text.Length < 11)
            {
                MessageBox.Show("Contact no. must be atleast 11 digits long.");
            }

            else if (!(NameText.Text.Equals("Full Name") || textBox1.Text.Equals("Blk No.") || textBox2.Text.Equals("Lot No.") || ContactText.Text.Equals("Contact No.")))
            {
                if (MessageBox.Show("Would you like to save this account?", "Save account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        String query = "insert into homeownerAccount (Name, blockNo, lotNo, contactNo) values ('" + NameText.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + ContactText.Text + "')";

                        using (connection = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand(query, connection))


                        {
                            connection.Open();

                            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                            var Mydata = NameText.Text;
                            var Mydata1 = textBox1.Text; //block no
                            var Mydata2 = textBox2.Text; //lot no
                            var Mydata3 = ContactText.Text;

                            var Mydata4 = Mydata + "," + Mydata1 + "," + Mydata2 + "," + Mydata3;
                            var Mydata5 = QG.CreateQrCode(Mydata4, QRCoder.QRCodeGenerator.ECCLevel.H);
                            var code = new QRCoder.QRCode(Mydata5);
                            pictureBox1.Image = code.GetGraphic(3);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Account successfully created.");
                            NameText.Text = null;
                            textBox1.Text = null;
                            textBox2.Text = null;
                            ContactText.Text = null;

                            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            pictureBox1.Image.Save(path + "\\" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg", ImageFormat.Jpeg);
                        }
                        PopulatehomeownerAccount();
                    }
                    catch (SqlException r)
                    {
                        switch (r.Number)
                        {
                            case 2627:
                                MessageBox.Show("Duplicate Name");
                                break;
                            case 208:
                                MessageBox.Show("Bad Obj");
                                break;
                            default:

                                MessageBox.Show("" + r);
                                break;
                        }
                    }

                }

            }

        }
      
    }
}
