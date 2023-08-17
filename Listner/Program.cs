using System.Net;

namespace Listner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                SimpleListenerExample(new string[] { "http://localhost:8888/" });
            }
        }

        public static void SimpleListenerExample(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");
            HttpListener listener = new HttpListener();

            foreach (var s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            Console.WriteLine("Listening...");

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            Console.WriteLine($"Request recieved: {request.Url.OriginalString}");
            Console.WriteLine(request.Url.OriginalString);

            var responseData = Controller.ExecuteRequest(request.Url.LocalPath.Trim('/'));

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseData.ResponseText);
            response.StatusCode = (int)responseData.statusCode;
            if (responseData.Header != "")
            {
                response.Headers.Add("X-MyName", responseData.Header);
            }

            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();
            listener.Stop();
        }
    }
}