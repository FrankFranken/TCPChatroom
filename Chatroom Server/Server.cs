using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Chatroom_Server
{
    public class Server
    {
        public static Queue<string> chatQueue = new Queue<string>();
        string clientUser;

        public Server(string IPAddress, int Socket)
        {
            TCPListenerSocket();
        }
        public void TCPListenerSocket()
        {
            TcpListener server = null;
            {
                try
                {
                    Int32 socket = 5150;
                    IPAddress localAddress = IPAddress.Any;
                    server = new TcpListener(localAddress, socket);
                    server.Start();
                    Byte[] bytes = new Byte[256];
                    string data = null;

                    while (true)
                    {
                        Console.Write("Atempting to connect");
                        TcpClient client = server.AcceptTcpClient();
                        
                        Console.WriteLine("\nConnected");
                        data = null;
                        NetworkStream stream = client.GetStream();

                        int i;

                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {

                            data = Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);
                            data = data.ToLower();                           
                            byte[] msg = Encoding.ASCII.GetBytes(data);
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", data);
                            
                           
                            
                        }
                        client.Close();
                }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                finally
                {
                    server.Stop();
                }
                Console.WriteLine("\nHit enter to continue...");
                Console.Read();
            }

        }
        public void NewUsers()
        {

            
        }



    }
}

