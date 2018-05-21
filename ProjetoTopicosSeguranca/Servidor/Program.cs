using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    class Program
    {
        private const int PORT = 9999;

        static void Main(string[] args)
        {
            TcpListener tcpListener = null;
            TcpClient tcpclient = null;
            NetworkStream network_stream = null;


            //try
            //{
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, PORT);
                tcpListener = new TcpListener(endpoint);

                Console.WriteLine("Starting Server...");
                tcpListener.Start();
                Console.ReadKey();

                
            //}
            }
    }
}
