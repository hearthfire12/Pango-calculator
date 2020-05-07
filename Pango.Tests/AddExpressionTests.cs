using FluentAssertions;
using Pango_Lib.Expressions;
using Xunit;

namespace Pango.Tests
{
    public class AddExpressionTests
    {
        [Theory]
        [InlineData(5, 5, 10)]
        [InlineData(15, 5, 20)]
        [InlineData(-1, 3, 2)]
        public void Add(decimal left, decimal right, decimal expectedResult)
        {
            var leftExp = new ConstantExpression(left);
            var rightExp = new ConstantExpression(right);
            var expression = new AddExpression(leftExp, rightExp);

            var result = expression.Calculate();

            result.Should().Be(expectedResult);
        }
        
        // TODO: add more tests
    }
}