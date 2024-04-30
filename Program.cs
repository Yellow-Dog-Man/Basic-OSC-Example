using Rug.Osc;
using System.Net;

namespace OSCTester;

internal class Program
{
    static void Main(string[] args)
    {

        IPAddress address = IPAddress.Parse(args[0]);
        int port = int.Parse(args[1]);

        Console.WriteLine($"Connecting to {address} on port {port}");
        OscSender sender = new OscSender(address, port);
        sender.Connect();
        while (true)
        {
            var seconds = DateTimeOffset.Now.ToUnixTimeSeconds();
            Console.WriteLine("Sending: " + seconds);
            sender.Send(new OscMessage("/test", seconds));
        }
    }
}



