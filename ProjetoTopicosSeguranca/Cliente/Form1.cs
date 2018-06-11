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
using System.Threading;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valor = "1";
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);
            TcpClient tcpClient = new TcpClient();

            tcpClient.Connect(endPoint);
            NetworkStream networkStream = tcpClient.GetStream();

            ProtocolSI protocolSI = new ProtocolSI();
                        
           byte[] enviofuncao = protocolSI.Make(ProtocolSICmdType.DATA, "1");
           networkStream.Write(enviofuncao, 0, enviofuncao.Length);
            Thread.Sleep(1000);
           
            byte[] username = protocolSI.Make(ProtocolSICmdType.DATA, textBoxUsername.Text);
            networkStream.Write(username, 0, username.Length);
            Thread.Sleep(1000);

            byte[] password = protocolSI.Make(ProtocolSICmdType.DATA,TextBoxPassword.Text);
            networkStream.Write(password,0,password.Length);

        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            string valor = "2";
            string confirm;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);
            TcpClient tcpClient = new TcpClient();

            tcpClient.Connect(endPoint);
            NetworkStream networkStream = tcpClient.GetStream();

            ProtocolSI protocolSI = new ProtocolSI();

            byte[] enviofuncao = protocolSI.Make(ProtocolSICmdType.DATA, "2");
            networkStream.Write(enviofuncao, 0, enviofuncao.Length);
            Thread.Sleep(1000);

            byte[] username = protocolSI.Make(ProtocolSICmdType.DATA, textBoxUsername.Text);
            networkStream.Write(username, 0, username.Length);
            Thread.Sleep(1000);

            byte[] password = protocolSI.Make(ProtocolSICmdType.DATA, TextBoxPassword.Text);
            networkStream.Write(password, 0, password.Length);
           


                buttonEnviarFicheiro.Enabled = true;
            networkStream.Close();

        }

        private void buttonEnviarFicheiro_Click(object sender, EventArgs e)
        {
            string valor = "3";
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);
            TcpClient tcpClient = new TcpClient();

            tcpClient.Connect(endPoint);
            NetworkStream networkStream = tcpClient.GetStream();

            ProtocolSI protocolSI = new ProtocolSI();

            byte[] enviofuncao = protocolSI.Make(ProtocolSICmdType.DATA, "3");
            networkStream.Write(enviofuncao, 0, enviofuncao.Length);
            Thread.Sleep(1000);
        }
    }
}
