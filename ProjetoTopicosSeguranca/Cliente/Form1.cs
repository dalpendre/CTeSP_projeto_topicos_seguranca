using EI.SI;
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

namespace Cliente
{
    

    public partial class Form1 : Form
    {
        private const int PORT = 10000;


        public Form1()
        {
            InitializeComponent();
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, PORT);
            TcpClient client = new TcpClient();

            client.Connect(endpoint);

            NetworkStream networkStream = client.GetStream();
            ProtocolSI protocolSI = new ProtocolSI();

        }
    }
}
