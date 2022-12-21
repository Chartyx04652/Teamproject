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

namespace QrSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel11.BackColor = SystemColors.Control;
            textBox4.BackColor = SystemColors.Control;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
            panel11.BackColor = Color.White;
            textBox3.BackColor = SystemColors.Control;
            panel12.BackColor = SystemColors.Control;
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            textBox4.UseSystemPasswordChar = false;
        }

        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }
    }
}
