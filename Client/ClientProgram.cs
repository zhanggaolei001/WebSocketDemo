using System;
using WebSocketSharp;

namespace Client
{
    public class ClientProgram
    {
        public static void Main(string[] args)
        {
            using (var ws = new WebSocket("ws://127.0.0.1:8888/Hello"))
            {
                ws.OnMessage += (sender, e) =>
                    Console.WriteLine("Laputa says: " + e.Data);

                ws.Connect();
                ws.Send("Hello World");
                Console.ReadKey(true);
            }
        }
    }
}
