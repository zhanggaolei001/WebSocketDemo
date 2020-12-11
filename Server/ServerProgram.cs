using System;
using System.Net;
using System.Net.Sockets;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{

    class ServerProgram
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer(8888);
            wssv.AddWebSocketService<Laputa>("/Hello");
            wssv.Start();
            Console.ReadKey(true);
            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
            }
            wssv.Stop();
        }
        class Laputa : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                Console.WriteLine("Got message from client:" + e.Data);
                Send("Hi,client,I'm the server ,I've got your message:" + e.Data);
            }
        }
    }
}
