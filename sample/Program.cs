using System;
using System.Threading;
using Sample.Generators;
using Sample.Sink;
using Serilog;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting application producing log events...");

            var logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                //.WriteTo.Console()
                //.WriteTo.Http("http://localhost:8080/log-events", httpClient: new CustomHttpClient())
                .CreateLogger()
                .ForContext<Program>();

            var customerGenerator = new CustomerGenerator();
            var orderGenerator = new OrderGenerator();

            while (true)
            {
                var customer = customerGenerator.Generate();
                var order = orderGenerator.Generate();

                logger.Information("{@customer} placed {@order}", customer, order);

                Thread.Sleep(1000);
            }
        }
    }
}
