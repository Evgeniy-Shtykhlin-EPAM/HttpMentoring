using System.Net;

namespace Listner
{
    public static class Controller
    {
        public static ResponseListen ExecuteRequest(string methodName)
        {
            switch (methodName)
            {
                case "MyName":
                    return new ResponseListen() { ResponseText = GetMyName(), statusCode = HttpStatusCode.OK };
                    break;

                // по заданию здесь код Information но когда я его использую выдает ошибку, я так понял он должен быть использован в процессе другого запроса
                case "Information":
                    return new ResponseListen() { ResponseText = "1xx – Information", statusCode = HttpStatusCode.OK };
                    break;
                case "Success":
                    return new ResponseListen() { ResponseText = "2xx – Success", statusCode = HttpStatusCode.OK };
                    break;
                case "Redirection":
                    return new ResponseListen() { ResponseText = "3xx – Redirection", statusCode = HttpStatusCode.Redirect };
                    break;
                case "ClientError":
                    return new ResponseListen() { ResponseText = "4xx – Client error", statusCode = HttpStatusCode.NotFound };
                    break;
                case "ServerError":
                    return new ResponseListen() { ResponseText = "5xx – Server error", statusCode = HttpStatusCode.InternalServerError };
                    break;
                case "MyNameByHeader":
                    return new ResponseListen() { Header = GetMyName(), statusCode = HttpStatusCode.OK, ResponseText = "" };
                    break;


                default:
                    return new ResponseListen() { ResponseText = "Url Not Found!", statusCode = HttpStatusCode.NotFound };
                    break;
            }
        }
        private static string GetMyName()
        {
            return "Yevgeniy";
        }
    }
}
