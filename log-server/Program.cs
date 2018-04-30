using System;
using Microsoft.Owin.Hosting;

namespace LogServer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting application consuming log events...");

            using (WebApp.Start<Startup>("http://localhost:8080/"))
            {
                Console.WriteLine("Press any key to stop the log server...");
                Console.ReadLine();
            }
        }
    }
}
