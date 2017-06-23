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
        static private byte[] DB2 = new byte[512];
        static private byte[] DB3 = new byte[512];
        static void Main(string[] args)
        {
            Server = new S7Server();
            Client = new S7Client();

            Server.RegisterArea(S7Server.srvAreaDB, 1, DB1, DB1.Length);
            Server.RegisterArea(S7Server.srvAreaDB, 2, DB2, DB2.Length);
            Server.RegisterArea(S7Server.srvAreaDB, 3, DB3, DB2.Length);
            int errorcode = Server.Start();
            Client.SetConnectionParams("127.0.0.1", 0, 2);
            Client.Connect();
            Client.DBWrite(2, 0, 4, new byte []{ 1, 2, 3, 4 });
            byte[] b = new byte[4];
           
            S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
            Client.GetCpuInfo(ref info);
            Console.WriteLine(info.ASName);
            Console.WriteLine(Client.Connected());
            Console.WriteLine(errorcode);


            Console.ReadLine();
        }
    }
}
