using Pango_Lib.Expressions.Contract;

namespace Pango_Lib.Expressions
{
    public class MultiplyExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public MultiplyExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }
        
        public OperationType Operation => OperationType.Multiply;
        public decimal Calculate()
        {
            return _left.Calculate() * _right.Calculate();
        }
    }
}