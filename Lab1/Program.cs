using System.Net.Sockets;
using System.Net;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hostname = Dns.GetHostName();
            if (args.Any())
            {
                hostname = args[0];
            }
            var ipAddress = GetLocalIPAddress(hostname);
            Console.WriteLine($"Hostname: {hostname}");
            Console.WriteLine($"Return internet IP address of {hostname}");
            Console.WriteLine(ipAddress);
            Console.Write("Return again hostname: ");
            Console.WriteLine(GetHostName(ipAddress));


        }

        public static string GetLocalIPAddress(string hostname)
        {
            var host = Dns.GetHostEntry(hostname);
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No internet network adapters found");
        }

        public static string GetHostName(string ip)
        {
            var host = Dns.GetHostEntry(ip);
            return host.HostName;
        }
    }
}