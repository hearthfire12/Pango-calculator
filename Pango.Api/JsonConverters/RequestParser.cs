using System;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using Pango_Lib.Expressions;
using Pango_Lib.Expressions.Contract;
using Pango.Api.Models;

namespace Pango.Api.JsonConverters
{
    public class RequestParser : IRequestParser
    {
        public Request ParseRequest(string json)
        {
            var jObject = JObject.Parse(json);

            if (!Enum.TryParse(jObject["client"].Value<string>(), out ClientType client))
            {
                throw new NotSupportedException(nameof(ClientType));
            }

            var expression = ParseExpression(jObject["expression"]);
            return new Request(client, expression);
        }
        
        private static IExpression ParseExpression(JToken expression)
        {
            var operationString = expression["operation"].Value<string>();
            if (!Enum.TryParse(operationString, out OperationType operation))
            {
                throw new InvalidEnumArgumentException(nameof(OperationType));
            }

            switch (operation)
            {
                case OperationType.Constant:
                    return new ConstantExpression(expression["value"].Value<decimal>());
                case OperationType.Add:
                    return new AddExpression(ParseExpression(expression["left"]), ParseExpression(expression["right"]));
                case OperationType.Multiply:
                    return new MultiplyExpression(ParseExpression(expression["left"]), ParseExpression(expression["right"]));
                default:
                    throw new NotSupportedException();
            }
        }
    }
}