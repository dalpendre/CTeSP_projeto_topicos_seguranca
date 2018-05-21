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
        private const int PORT = 9999;
        TcpClient tcpclient = null;
        NetworkStream networkstream = null;

        public Form1()
        {
            InitializeComponent();


        }

        private void buttonEnviarMensagem_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quer mesmo conectar ao Servidor?", "Conecçao", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //Ativar a textbox e o button
                textBoxMensagem.Enabled = true;
                buttonEnviarMensagem.Enabled = true;


                IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, PORT);
                tcpclient = new TcpClient();

                tcpclient.Connect(endpoint);
                networkstream = tcpclient.GetStream();
            }
            else
            {
                return;
            }
        }
    }
}
