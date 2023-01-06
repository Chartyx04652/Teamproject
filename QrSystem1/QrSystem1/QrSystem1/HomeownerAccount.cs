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
using System.Windows.Forms.VisualStyles;
using System.Windows.Controls;
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
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from homeownerAccount", connection))
            {
                DataTable homeownerAccountTable = new DataTable();
                adapter.Fill(homeownerAccountTable);
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

        

        private void button2_Click(object sender, EventArgs e)
        {
            int number;
            bool result = Int32.TryParse(textBox1.Text, out number);
            bool result1 = Int32.TryParse(textBox2.Text, out number);
            bool result2 = Int32.TryParse(ContactText.Text, out number);
            Convert.ToString(result);
            Convert.ToString(result1);
            Convert.ToString(result2);
            

                if (NameText.Text.Equals("Full Name") || textBox1.Text.Equals("Blk No.") || textBox2.Text.Equals("Lot No.") || ContactText.Text.Equals("Contact No."))
                {
                    MessageBox.Show("Please fill up empty form/s.");
                }
                else if (ContactText.Text.Length < 11)
                {
                    MessageBox.Show("Contact no. must be atleast 11 digits long.");
                }
                else if (result.Equals("False")|| result1.Equals("False") || result2.Equals("False"))
                {
                    MessageBox.Show("Invalid Input");
                }


                else if (!(NameText.Text.Equals("Full Name") || textBox1.Text.Equals("Blk No.") || textBox2.Text.Equals("Lot No.") || ContactText.Text.Equals("Contact No.")))
                {
                    

                String query = "insert into homeownerAccount (Name, blockNo, lotNo, contactNo) values ('" + NameText.Text + "', '"+ textBox1.Text + "', '"+ textBox2.Text + "', '"+ ContactText.Text + "')";
                String query1 = "select * from homeownerAccount where Name = Name";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlCommand cmd1 = new SqlCommand(query1, connection))

                {
                    connection.Open();


                    
                    SqlDataReader dataReader = cmd1.ExecuteReader();
                    if (dataReader.Read())
                    {
                        MessageBox.Show("This account already exists.");
                        dataReader.Close();
                    }
                    else
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

                        cmd.ExecuteNonQuery();
                    }
                    
                }
                PopulatehomeownerAccount();
    
                    //string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    //string path = (System.IO.Path.GetDirectoryName(executable));
                    //AppDomain.CurrentDomain.SetData("DataDirectory", path);
                    //SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf;Integrated Security=True");
                    //conn.Open();

                    //if (conn.State == System.Data.ConnectionState.Open)
                    //{
                    //    string q = "insert into HO_Account(fullName, blockNo, lotNo, contactNo) values ('" + "','" +NameText.Text.ToString() + "','" + Convert.ToInt32(textBox1.Text) + "','" + Convert.ToInt32(textBox2.Text) + "','" + ContactText.Text.ToString()+ "')";
                    //    SqlCommand cmd = new SqlCommand(q,conn);
                    //    cmd.ExecuteNonQuery();
                    //}

                }

            

        }

        
    }
}
