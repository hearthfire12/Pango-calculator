using Pango_Lib.Expressions.Contract;

namespace Pango_Lib.Expressions
{
    public class ConstantExpression : IExpression
    {
        private readonly decimal _value;

        public ConstantExpression(decimal value)
        {
            _value = value;
        }

        public OperationType Operation => OperationType.Constant;

        public decimal Calculate()
        {
            return _value;
        }
    }
}