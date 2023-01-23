using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.ServiceModel.Configuration;

namespace QrSystem1
{
    public partial class LoginForm : Form
    {   int tries = 3;
        String password;
        String username;
        String connectionString;
        SqlConnection connection;
        Class1 cl = new Class1();
        public LoginForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QrSystem1.Properties.Settings.UserAccountConnectionString"].ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the app.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            username = textBox1.Text;
            password = textBox2.Text;
            String pass = cl.encrypt(password.ToCharArray());
            String query = $"select username,password from Accounts where username = '{username}' and password = '{pass}'";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    if (tries == 1)
                    {
                        MessageBox.Show("Maximum attempts reached.", "Exit");
                        Application.Exit();
                    }
                    MessageBox.Show("Login failed.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    tries--;
                }
                else
                {
                    MessageBox.Show("Logged in successfully.");
                    this.Hide();
                    Form1 ss = new Form1();
                    ss.Show();
                }
            }          
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                button2.PerformClick();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                button2.PerformClick();
            }
        }
    }
}
