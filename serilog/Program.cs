using System.Threading;
using Serilog.Generators;

namespace Serilog
{
    class Program
    {
        static void Main()
        {
            ILogger logger = new LoggerConfiguration()
                .WriteTo.DurableHttp("http://logstash:8080")
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
