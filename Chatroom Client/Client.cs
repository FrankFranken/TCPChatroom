﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Chatroom_Client
{
    class Client : IObservable<Client>
    {

        public Client(string IPAddress, int Socket)
        {
            Connect("","");
        }
        static void Connect(string server, string message)
        {
            try
            {

                Int32 socket = 5150;
                TcpClient client = new TcpClient(server, socket);
                Console.WriteLine("Please enter your name:");
                message = Console.ReadLine();
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
            Console.WriteLine("Hello");
            //Console.WriteLine("Start typing your chat message");
            //string userinput = Console.ReadLine();
            //Console.WriteLine((message )  +  ( userinput));
            Console.ReadLine();
        }

        public IDisposable Subscribe(IObserver<Client> observer)
        {
            throw new NotImplementedException();
        }
    }
}
