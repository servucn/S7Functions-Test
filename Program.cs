using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace S7Functions
{
    class Program
    {
        static S7Server Server;
        static S7Client Client;
        static private byte[] DB1 = new byte[512];
        static void Main(string[] args)
        {
            Server = new S7Server();
         

            Server.RegisterArea(S7Server.srvAreaDB, 1, DB1, DB1.Length);
            int errorcode = Server.Start();

            Client = new S7Client();
            Client.Connect();
            Client.ConnectTo("127.0.0.1", 0, 2);
            Client.WriteArea(S7Server.srvAreaDB, 1, 0, 20, 2, new byte[] { 1, 2, 3 });
            Console.WriteLine(errorcode);

            while (true)
            {
                Thread.Sleep(3000);

            }
            Console.ReadLine();
        }
    }
}
