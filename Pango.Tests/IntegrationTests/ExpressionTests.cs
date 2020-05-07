using FluentAssertions;
using Pango_Lib;
using Pango_Lib.Expressions.Contract;
using Xunit;

namespace Pango.Tests.IntegrationTests
{
    public class ExpressionTests
    {
        private readonly ExpressionFactory _factory = new ExpressionFactory();

        [Theory]
        [InlineData(OperationType.Add, 4, 6, 10)]
        [InlineData(OperationType.Constant, 4, 0, 4)]
        [InlineData(OperationType.Multiply, 4, 4, 16)]
        public void SingleOperation(OperationType operation, decimal left, decimal right, decimal expectedResult)
        {
            var exp = _factory.FromOperation(operation, _factory.Const(left), _factory.Const(right));
            exp.Calculate().Should().Be(expectedResult);
        }

        [Fact]
        public void MultipleOperations() // 4+4*4+4
        {
            var multiplyOperation = _factory.FromOperation(OperationType.Multiply, _factory.Const(4), _factory.Const(4));
            var firstAddOperation = _factory.FromOperation(OperationType.Add, _factory.Const(4), multiplyOperation);
            var secondAddOperation = _factory.FromOperation(OperationType.Add, firstAddOperation, _factory.Const(4));
            secondAddOperation.Calculate().Should().Be(24);
        }
    }
}
