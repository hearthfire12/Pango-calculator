using System;
using Newtonsoft.Json.Linq;
using Pango_Lib;
using Pango.Api.Models;

namespace Pango.Api.JsonConverters
{
    // TODO: should be moved to RequestJsonConverter
    public class RequestParser
    {
        private readonly ExpressionParser _parser;

        public RequestParser(ExpressionParser parser)
        {
            _parser = parser;
        }

        public Request ParseRequest(string json)
        {
            var jObject = JObject.Parse(json);

            if (!Enum.TryParse(jObject["client"].Value<string>(), out ClientType client))
            {
                throw new NotSupportedException(nameof(ClientType));
            }

            var expression = _parser.ParseExpression(jObject["asd"].Value<string>());
            return new Request(client, expression);
        }
    }
}