using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task SV = new Task(() =>
            {
                TcpListener tcpSever = new TcpListener(IPAddress.Any, 8080);
                tcpSever.Start();

                while(true)
                {
                    TcpClient tcpClient = tcpSever.AcceptTcpClient();
                    NetworkStream steam = tcpClient.GetStream();

                    byte[] recvBytes = new byte[256];
                    int i = steam.Read(recvBytes, 0, recvBytes.Length);

                    string data = Encoding.UTF8.GetString(recvBytes,0,i);

                    
                    //UdpClient udpClient = new UdpClient();

                    //udpClient.Send(recvBytes, i, new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2222));
                    //udpClient.Send(recvBytes, i, new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2221));
                    //udpClient.Send(recvBytes, i, new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2223));

                    
                    listView1.Items.Add(new ListViewItem(new string[] { tcpClient.Client.RemoteEndPoint.ToString(),data}));

                }
            });
            SV.Start();
            MessageBox.Show("Sever is running");

        }
    }
}
