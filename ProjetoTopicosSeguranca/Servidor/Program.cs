using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servidor
{
    

    class Program
    {
        private const int PORT = 10000;

        static void Main(string[] args)
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any,PORT);
            TcpListener listener = new TcpListener(endpoint);
            listener.Start();
            Console.WriteLine("Server Ready");


            //aceita cliente
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");


           
          

        }

    }

    

    //SqlConnection conn = null;
}

