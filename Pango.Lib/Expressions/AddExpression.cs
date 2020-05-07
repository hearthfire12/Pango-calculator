using Pango_Lib.Expressions.Contract;

namespace Pango_Lib.Expressions
{
    public class AddExpression: IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public AddExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }
        
        public OperationType Operation => OperationType.Add;

        public decimal Calculate()
        {
            return _left.Calculate() + _right.Calculate();
        }
    }
}