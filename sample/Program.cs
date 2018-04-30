using System;
using System.Threading;
using Sample.Generators;
using Serilog;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting application producing log events...");

            ILogger logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
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
