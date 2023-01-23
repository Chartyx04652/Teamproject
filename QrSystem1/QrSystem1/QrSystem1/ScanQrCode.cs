using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using AForge;
using AForge.Video.DirectShow;
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceModel.Configuration;
using AForge.Video;
using System.Windows.Media.Imaging;

namespace QrSystem1
{
    public partial class ScanQrCode : Form
    {
        String connectionString;
        SqlConnection connection;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice VideoCaptureDevice;
        String QrContent;
        

        public ScanQrCode()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QrSystem1.Properties.Settings.UserAccountConnectionString"].ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ExistingAcccount frm = new ExistingAcccount();
            frm.Show();
        }
        private void ScanQrCode_Load_1(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                cbCameraList.Items.Add(device.Name);
                cbCameraList.SelectedIndex = 0;
            }
            VideoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameraList.SelectedIndex].MonikerString);
            VideoCaptureDevice.NewFrame += VideoCaptureDevice_Form;
            VideoCaptureDevice.Start();

            PopulatehomeownerHistory();
            PopulatevisitorHistory();

        }
        private void PopulatehomeownerHistory()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand com = new SqlCommand("select * from homeownerHistory", connection))

            {
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
            }

        }
        private void PopulatevisitorHistory()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand com = new SqlCommand("select * from visitorHistory", connection))
            {
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
            }
        }

        bool scanQR = false;

        private void VideoCaptureDevice_Form(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            if (scanQR)
            {
                BarcodeReader barcode = new BarcodeReader();
                Result result = barcode.Decode(bitmap);
                if (result != null)
                {
                    QrContent = result.ToString();
                    String[] qrcontent = QrContent.Split(',');
                    String QRContent = qrcontent[0];
                    String query = $"select * from homeownerAccount where Name = '{QRContent}'";

                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (!reader.Read())
                        {
                            String query1 = $"select * from visitorAccount where Name = '{QRContent}'";
                            using (connection = new SqlConnection(connectionString))
                            using (SqlCommand cmd1 = new SqlCommand(query1, connection))
                            {
                                connection.Open();
                                SqlDataReader reader1 = cmd1.ExecuteReader();
                                if (!reader1.Read())
                                {
                                    MessageBox.Show("Account does not exist.");
                                    button2.Text = "&Scan";
                                    scanQR = false;
                                }
                                else 
                                {
                                    MessageBox.Show("Gates open.");
                                    button2.Text = "&Scan";
                                    scanQR = false;
                                    String query3 = $"insert into visitorHistory (Name, purposeOfVisit, dateAndTime) values('{qrcontent[0]}','{qrcontent[1]}',getdate())";
                                    using (connection = new SqlConnection(connectionString))
                                    using (SqlCommand cmd2 = new SqlCommand(query3, connection))
                                    {
                                        connection.Open();
                                        cmd2.ExecuteNonQuery();
                                    }
                                    PopulatevisitorHistory();
                                }
                            }

                            
                        }
                        else
                        {
                            MessageBox.Show("Gates open.");
                            button2.Text = "&Scan";
                            scanQR = false; 
                            String query2 = $"insert into homeownerHistory (Name, blockNo, lotNo, contactNo, dateAndTime) values('{qrcontent[0]}','{qrcontent[1]}','{qrcontent[2]}','{qrcontent[3]}',getdate())";
                            using (connection = new SqlConnection(connectionString))
                            using (SqlCommand cmd3 = new SqlCommand(query2, connection))
                            {
                                connection.Open();
                                cmd3.ExecuteNonQuery();
                            }
                            PopulatehomeownerHistory();
                        }
                    }                   
                }
            }
            picBox.Image = bitmap;
        }
        private void ScanBtn_Click(object sender, EventArgs e)
        {
            button2.Text = "Scanning...";
            scanQR = true;
        }


        private void ScanQrCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (VideoCaptureDevice != null)
            {
                if (VideoCaptureDevice.IsRunning)
                    VideoCaptureDevice.Stop();
            }
        }

        private void ScanQrCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.S)
            {
                button2.PerformClick();
            }
            
            
        }
    }
}
