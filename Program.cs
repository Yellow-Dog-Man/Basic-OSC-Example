using Rug.Osc;
using System.Net;

namespace OSCTester;

internal class Program
{
    static async Task Main(string[] args)
    {
        var tasks = new List<Task>();

        // Receive
        if (args.Length == 3 || args.Length == 1)
        {
            int port = 0;

            if (args.Length == 3)
                port = int.Parse(args[2]);
            if (args.Length == 1)
                port = int.Parse(args[0]);

            Console.WriteLine($"Receiving on {port}");
            OscReceiver receiver = new OscReceiver(port);
            receiver.Connect();



            var t = Task.Run(() =>
            {
                while (true)
                {
                    var success = receiver.TryReceive(out var message);
                    if (success)
                        Console.WriteLine($"Receive: " + message);

                }
            });
            tasks.Add(t);
        }

        //Send
        if (args.Length >= 2)
        {
            IPAddress address = IPAddress.Parse(args[0]);
            int port = int.Parse(args[1]);

            Console.WriteLine($"Connecting to {address} on port {port}");
            OscSender sender = new OscSender(address, port);
            sender.Connect();

            var t = Task.Run(async () =>
            {
                while (true)
                {
                    var seconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                    Console.WriteLine("Sending: " + seconds);
                    sender.Send(new OscMessage("/test", seconds));
                    await Task.Delay(500);
                }
            });
            tasks.Add(t);
        }

        if (tasks.Any())
            await Task.WhenAll(tasks);
    }
}



