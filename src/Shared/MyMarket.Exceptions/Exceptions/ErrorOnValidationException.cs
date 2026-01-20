using System.Net;

namespace MyMarket.Exceptions.Exceptions
{
    public class ErrorOnValidationException : MyMarketException
    {
        private readonly IList<string> _messageErrors;
        public ErrorOnValidationException(IList<string> errors) =>_messageErrors = errors;
        public IList<string> MessageErrors => _messageErrors;
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
