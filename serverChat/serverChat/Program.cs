using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace serverChat
{
    class Program
    {
        private const string _serverHost = "localhost";
        private const int _serverPort = 9933;
        private static Thread _serverThread;
        static void Main(string[] args)
        {
            // отдельным потоком начинаем работу сервера
            _serverThread = new Thread(startServer);
            _serverThread.IsBackground = true;
            _serverThread.Start();
            while (true)
                handlerCommands(Console.ReadLine());
        }
        // метод отлавливает команды, которые вводятся в консоль на сервере
        private static void handlerCommands(string cmd)
        {
            cmd = cmd.ToLower();
            if (cmd.Contains("/getusers"))
            {
                int countUsers = Server.Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    Console.WriteLine("[{0}]: {1}", i, Server.Clients[i].UserLogin);
                }
            }
        }
        // метод начинает работу сервера
        private static void startServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            socket.Listen(1000);
            Console.WriteLine("Server has been started on IP: {0}.", ipEndPoint.ToString());
            while (true)
            {
                try
                {
                    Socket user = socket.Accept();
                    Server.NewClient(user);
                }
                catch (Exception exp) { Console.WriteLine("Error: {0}", exp.Message); }
            }

        }
    }
}
