using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;

namespace QrSystem1
{
    public partial class VisitorsAccount : Form
    {
        String connectionString;
        SqlConnection connection;
        String path;
        public VisitorsAccount()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QrSystem1.Properties.Settings.UserAccountConnectionString"].ConnectionString;
        }
        private void VisitoryAccount_Load(object sender, EventArgs e)
        {
            PopulatevisitorAccount();
        }
        private void PopulatevisitorAccount()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand com = new SqlCommand("select * from visitorAccount", connection))

            {
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
            }

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
        private void NameText1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if (Char.IsWhiteSpace(e.KeyChar)) return;
            if (e.KeyChar == '.') return;
            e.Handled = true;
        }

        private void PurposeOfVisit_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if (Char.IsWhiteSpace(e.KeyChar)) return;
            e.Handled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!(NameText1.Text.Equals("Full Name") || PurposeOfVisit.Text.Equals("Purpose of Visit")))
            {
                if (MessageBox.Show("Would you like to save this account?", "Save account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        byte[] imgbt = null;
                        FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fstream);
                        imgbt = br.ReadBytes((int)fstream.Length);


                        String query = "insert into visitorAccount (Name, purposeOfVisit, idPicture) values ('" + NameText1.Text + "', '" + PurposeOfVisit.Text + "',@IMG)";

                        using (connection = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                            

                        {
                            connection.Open();
                            cmd.Parameters.Add(new SqlParameter("@IMG", imgbt));
                            SqlDataReader reader;
                            reader = cmd.ExecuteReader();

                            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                            var Mydata = NameText1.Text;
                            var Mydata1 = PurposeOfVisit.Text;
                            var Mydata2 = NameText1.Text + "," + PurposeOfVisit.Text;
                            var Mydata3 = QG.CreateQrCode(Mydata2, QRCoder.QRCodeGenerator.ECCLevel.H);
                            var code = new QRCoder.QRCode(Mydata3);
                            pictureimage1.Image = code.GetGraphic(3);

                            MessageBox.Show("Account succefully created.");
                            NameText1.Text = null;
                            PurposeOfVisit.Text = null;
                            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            pictureimage1.Image.Save(path + "\\" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg", ImageFormat.Jpeg);

                        }
                        PopulatevisitorAccount();
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
            else if (NameText1.Text.Equals("Full Name") || PurposeOfVisit.Text.Equals("Purpose of Visit"))
            {
                MessageBox.Show("Please fill up empty form/s.");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| ALL Files(*.*)|*.*";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    path = imageLocation;
                    pictureBox1.ImageLocation = imageLocation;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            
            

        }
        

      
    }
}
