using System.Net;

namespace Ludotheque.EvenementLocation
{

    public class EvenementLocationException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public EvenementLocationException(HttpStatusCode statusCode, string? message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
