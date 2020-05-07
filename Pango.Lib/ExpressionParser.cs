using System;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using Pango_Lib.Expressions;
using Pango_Lib.Expressions.Contract;

namespace Pango_Lib
{
    // TODO: should be moved to RequestJsonConverter
    public class ExpressionParser
    {
        public IExpression ParseExpression(string json)
        {
            var jObject = JObject.Parse(json);
            return ParseExpression(jObject);
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