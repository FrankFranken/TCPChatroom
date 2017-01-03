using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom_Server 
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            Server server = new Server("10.92.158.23", 5150);
           // Console.ReadKey();
        }
        
    }
}
