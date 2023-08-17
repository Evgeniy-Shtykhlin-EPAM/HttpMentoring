using System.Net;

namespace Listner
{
    public class ResponseListen
    {
        public string ResponseText { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string Header { get; set; } = "";
    }
}
