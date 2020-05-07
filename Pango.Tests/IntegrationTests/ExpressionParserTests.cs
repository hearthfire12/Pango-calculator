using FluentAssertions;
using Pango_Lib;
using Xunit;

namespace Pango.Tests.IntegrationTests
{
    // TODO: should check that each expression is constructed correctly, but not evaluate them
    public class ExpressionParserTests
    {
        private readonly ExpressionParser _parser = new ExpressionParser();

        [Fact]
        public void Constant()
        {
            const string json = @"
{
    operation: 'Constant',
    value: 4
}";

            var expression = _parser.ParseExpression(json);
            expression.Calculate().Should().Be(4);
        }

        [Fact]
        public void Add()
        {
            const string json = @"
{
    operation: 'Add',
    left: {
      operation: 'Constant',
      value: 4
    },
    right: {
      operation: 'Constant',
      value: 4
    }
}";
            
            var expression = _parser.ParseExpression(json);
            expression.Calculate().Should().Be(8);
        }
    }
}