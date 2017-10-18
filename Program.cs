using System;
using System.Diagnostics;
using System.Threading;
using Nancy.Hosting.Self;


namespace sample_dotnet_rest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new HostConfiguration
            {
                UrlReservations = new UrlReservations {CreateAutomatically = true}
            };
            using (var nancyHost = new NancyHost(configuration, new Uri("http://localhost:8888/v1/")))
            {
                nancyHost.Start();
                Console.WriteLine("Nancy now listening - navigating to http://localhost:8888/v1/.");
                try
                {
                    Process.Start("http://localhost:8888/v1/");
                }
                catch (Exception)
                {
                }
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}