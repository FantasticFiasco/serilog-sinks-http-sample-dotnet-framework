using System;
using System.Threading;
using Serilog.Generators;
using Serilog.Sink;

namespace Serilog
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting application producing log events...");

            ILogger logger = new LoggerConfiguration()
                .WriteTo.DurableHttp(
                    "http://localhost:8080/log-events",
                    httpClient: new CustomHttpClient())
                .WriteTo.Console()
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
