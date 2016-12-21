using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Chatroom_Client
{
    class Client : IObservable<string>
    {

        public Client()
        {
            Connect("","");
        }
        static void Connect(string server, string message)
        {
            try
            {
                Int32 socket = 5150;
                TcpClient client = new TcpClient(server, socket);
                Byte[] data = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                

                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
                data = new Byte[256];
                string responseData = string.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                stream.Close();
                client.Close();
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.WriteLine("\n Press Enter to continue");
            Console.Read();
        }

    }
}
