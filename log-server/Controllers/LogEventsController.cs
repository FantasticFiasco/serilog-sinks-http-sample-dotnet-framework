using System;
using System.Web.Http;

namespace LogServer.Controllers
{
    public class LogEventsController : ApiController
    {
        [Route("log-events")]
        public void Post([FromBody] LogEvents body)
        {
            foreach (var logEvent in body.Events)
            {
                Console.WriteLine(logEvent.Timestamp);
                Console.WriteLine($"[{logEvent.Level}] {logEvent.RenderedMessage}");
                Console.WriteLine();
            }
        }
    }
}
