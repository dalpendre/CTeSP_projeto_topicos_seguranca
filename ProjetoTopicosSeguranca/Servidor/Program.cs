using EI.SI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servidor
{
    

    class Program
    {
        private const int PORT = 10000;

        static RSACryptoServiceProvider rsaSign;

        //my main 
        static void Main(string[] args)
        {
            // Vars
            int Saltgador = 8;
            string ola = "ola";
            string end = "end";
            string var;
            byte[] salt = new byte[Saltgador];



            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any,PORT);
            TcpListener listener = new TcpListener(endpoint);
            listener.Start();
            Console.WriteLine("Server Ready");

            //while (true)
            
                //aceita cliente
               
            do
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");
                NetworkStream networkStream = client.GetStream();
                ProtocolSI protocolSI = new ProtocolSI();
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                var =  Convert.ToString(protocolSI.GetStringFromData());
                
                Thread.Sleep(1000);

                switch (var)
                {
                    case ("1"):

                        string username;
                        string password;

                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        username = protocolSI.GetStringFromData();
                        Console.WriteLine("Obetendo username com sucesso!");
                        Thread.Sleep(1000);

                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        password = protocolSI.GetStringFromData();
                        networkStream.Close();
                        client.Close();
                        Console.WriteLine("Otendo password com sucesso!");
                        Thread.Sleep(1000);

                        salt = GenerateSalt(Saltgador);
                        byte[] SaltedHash = GenerateSaltedHash(Encoding.UTF8.GetBytes(password), salt);
                        Register(username, SaltedHash, salt);
                        Console.WriteLine("Tudo Feito com sucesso!");
                            
                        
                        break;
                    case ("2"):
                        string usernamelogin;
                        string passwordlogin;
                        bool confirm;

                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        usernamelogin = protocolSI.GetStringFromData();
                        Console.WriteLine("Obetendo username com sucesso!");
                        Thread.Sleep(1000);

                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        passwordlogin = protocolSI.GetStringFromData();

                        Console.WriteLine("Otendo password com sucesso!");
                        Thread.Sleep(1000);

                        confirm = VerifyLogin(usernamelogin, passwordlogin);
                        Console.WriteLine("Fazendo Login!");

                        networkStream.Close();
                        client.Close();



                        break;
                    case ("3"):

                        enviarFicheiro();

                        break;
                    default:
                        Console.WriteLine("Nenhuma funçao atribuida nesse valor!");
                    break;
                }
            }while(var !="10");
                


           


        }

        //Gera Sal
        private static byte[] GenerateSalt(int size)
        {
            //gera numero aleatorio codificado
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            //Escrevendo Processo Log na Consola
            Console.WriteLine("Gerando Salt");
            return buff;
        }

        // Gera Hash Salgada
        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            using (HashAlgorithm hashAlgorithm = SHA512.Create())
            {
                // Declarar e inicializar buffer para o texto e salt
                byte[] plainTextWithSaltBytes =
                              new byte[plainText.Length + salt.Length];

                // Copiar texto para buffer
                for (int i = 0; i < plainText.Length; i++)
                {
                    plainTextWithSaltBytes[i] = plainText[i];
                }
                // Copiar salt para buffer a seguir ao texto
                for (int i = 0; i < salt.Length; i++)
                {
                    plainTextWithSaltBytes[plainText.Length + i] = salt[i];
                }

                //Escrevendo Processo Log na Consola
                Console.WriteLine("Gerando Hash Salgada");

                //Devolver hash do text + salt
                return hashAlgorithm.ComputeHash(plainTextWithSaltBytes);
            }
        }

        //Cria Utilizador
        private static void Register(string username, byte[] saltedPasswordHash, byte[] salt)
        {
            SqlConnection conn = null;
            try
            {
                // Configurar ligação à Base de Dados
                conn = new SqlConnection();
                conn.ConnectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\danie\source\repos\ProjetoTopicosSeguranca\Servidor\Database1.mdf;Integrated Security=True");

                // Abrir ligação à Base de Dados
                conn.Open();

                // Declaração dos parâmetros do comando SQL
                SqlParameter paramUsername = new SqlParameter("@username", username);
                SqlParameter paramPassHash = new SqlParameter("@saltedPasswordHash", saltedPasswordHash);
                SqlParameter paramSalt = new SqlParameter("@salt", salt);

                // Declaração do comando SQL
                String sql = "INSERT INTO Users (Username, SaltedPasswordHash, Salt) VALUES (@username,@saltedPasswordHash,@salt)";

                // Prepara comando SQL para ser executado na Base de Dados
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Introduzir valores aos parâmentros registados no comando SQL
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassHash);
                cmd.Parameters.Add(paramSalt);

                // Executar comando SQL
                int lines = cmd.ExecuteNonQuery();

                // Fechar ligação
                conn.Close();
                if (lines == 0)
                {
                    // Se forem devolvidas 0 linhas alteradas então o não foi executado com sucesso
                    throw new Exception("Error while inserting an user");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error while inserting an user:" + e.Message);
            }

            //Escrevendo no Log
            Console.WriteLine("Criando Utilizador");
        }

        // Verifica se o utilizador existe
        private static bool VerifyLogin(string username, string password)
        {
            SqlConnection conn = null;
            try
            {
                // Configurar ligação à Base de Dados
                conn = new SqlConnection();
                conn.ConnectionString = String.Format(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\danie\source\repos\ProjetoTopicosSeguranca\Servidor\Database1.mdf; Integrated Security = True");

                // Abrir ligação à Base de Dados
                conn.Open();

                // Declaração do comando SQL
                String sql = "SELECT * FROM Users WHERE Username = @username";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;

                // Declaração dos parâmetros do comando SQL
                SqlParameter param = new SqlParameter("@username", username);

                // Introduzir valor ao parâmentro registado no comando SQL
                cmd.Parameters.Add(param);

                // Associar ligação à Base de Dados ao comando a ser executado
                cmd.Connection = conn;

                // Executar comando SQL
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    throw new Exception("Error while trying to access an user");
                }

                // Ler resultado da pesquisa
                reader.Read();

                // Obter Hash (password + salt)
                byte[] saltedPasswordHashStored = (byte[])reader["SaltedPasswordHash"];

                // Obter salt
                byte[] saltStored = (byte[])reader["Salt"];

                conn.Close();

                //TODO: verificar se a password na base de dados 
                byte[] plaintext = GenerateSaltedHash(Encoding.UTF8.GetBytes(password), saltStored);
                return saltedPasswordHashStored.SequenceEqual(plaintext);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
                return false;
            }
        }

        static void enviarFicheiro()
        {
            string originFile = @".\security.jpg";
            string copiedFile = @".\copy_security.jpg";

            try
            {

                Console.WriteLine("A copiar...");
                File.Copy(originFile, copiedFile, true);
                Console.WriteLine("!Ficheiro copiado!");
            }
            catch
            {
                Console.WriteLine("Ficheiro não copiado");
            }
        }




    }

    

    
}

