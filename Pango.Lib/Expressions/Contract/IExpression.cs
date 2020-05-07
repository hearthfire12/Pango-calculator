namespace Pango_Lib.Expressions.Contract
{
    public interface IExpression
    {
        OperationType Operation { get; }
        decimal Calculate();
    }
}