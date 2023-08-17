using System.Net;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Write Method Name:");
                var methodName = Console.ReadLine();
                var returnResult = CallMethod(methodName);
                Console.WriteLine(returnResult);
            }
        }

        private static string CallMethod(string methodName)
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            using (HttpClient client = new HttpClient(handler))
            {
                var result = client.GetAsync($"http://localhost:8888/{methodName}/").GetAwaiter().GetResult();
                var parameters = new Dictionary<string, string>();

                var contents = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine(result.StatusCode.ToString());

                if (methodName == "MyNameByHeader")
                {
                    Console.WriteLine("Headers: ");
                    foreach (var header in result.Headers)
                    {
                        Console.WriteLine("\t Header Key: "+header.Key);
                    }
                }

                return contents;
            }
        }
    }
}