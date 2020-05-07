using Pango_Lib.Expressions.Contract;

namespace Pango.Api.Models
{
    public class Request
    {
        public Request(ClientType client, IExpression expression)
        {
            Client = client;
            Expression = expression;
        }
        
        public IExpression Expression { get; set; }
        public ClientType Client { get; set; }
    }
}