using System;
using Pango_Lib.Expressions;
using Pango_Lib.Expressions.Contract;

namespace Pango_Lib
{
    public class ExpressionFactory
    {
        public IExpression Const(decimal value)
        {
            return new ConstantExpression(value);
        }

        public AddExpression Add(IExpression left, IExpression right)
        {
            return new AddExpression(left, right);
        }

        public MultiplyExpression Multiply(IExpression left, IExpression right)
        {
            return new MultiplyExpression(left, right);
        }

        public IExpression FromOperation(OperationType operation, IExpression left, IExpression right)
        {
            switch (operation)
            {
                case OperationType.Constant: return left;
                case OperationType.Add: return Add(left, right);
                case OperationType.Multiply: return Multiply(left, right);
                default: throw new NotSupportedException(operation.ToString());
            }
        }
    }
}