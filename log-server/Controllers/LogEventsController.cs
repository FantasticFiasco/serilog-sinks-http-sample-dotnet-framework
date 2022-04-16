using System;
using System.Linq;
using System.Web.Http;

namespace LogServer.Controllers
{
    public class LogEventsController : ApiController
    {
        [Route("log-events")]
        public void Post([FromBody] LogEvent[] body)
        {
            Console.WriteLine("Received batch of log events");
            Console.WriteLine("================================================================================");
            Console.WriteLine($"API Key:\t{Request.Headers.GetValues("X-Api-Key").First()}");
            Console.WriteLine($"Nbr of events:\t{body.Length}");
            Console.WriteLine("Events:");

            foreach (var logEvent in body)
            {
                Console.WriteLine($"\t\t{logEvent.Timestamp} [{logEvent.Level}] {logEvent.RenderedMessage}");
            }

            Console.WriteLine(string.Empty);
        }
    }
}
