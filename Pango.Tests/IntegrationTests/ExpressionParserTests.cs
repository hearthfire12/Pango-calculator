using FluentAssertions;
using Pango.Api.JsonConverters;
using Xunit;

namespace Pango.Tests.IntegrationTests
{
    // TODO: should check that each expression is constructed correctly, but not evaluate them
    public class ExpressionParserTests
    {
        private readonly RequestParser _parser = new RequestParser();

        [Fact]
        public void Constant()
        {
            const string json = @"
{
    client: 'Desktop',
    expression: {
        operation: 'Constant',
        value: 4
    }
}";

            var request = _parser.ParseRequest(json);
            request.Expression.Calculate().Should().Be(4);
        }

        [Fact]
        public void Add()
        {
            const string json = @"
{
    client: 'Desktop',
    expression: {
        operation: 'Add',
        left: {
          operation: 'Constant',
          value: 4
        },
        right: {
          operation: 'Constant',
          value: 4
        }
    }
}";
            
            var request = _parser.ParseRequest(json);
            request.Expression.Calculate().Should().Be(8);
        }
    }
}