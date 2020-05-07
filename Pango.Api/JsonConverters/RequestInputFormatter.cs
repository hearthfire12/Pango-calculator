using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace Pango.Api.JsonConverters
{
    public class RequestInputFormatter : InputFormatter
    {
        private readonly IRequestParser _requestParser;

        public RequestInputFormatter(IRequestParser requestParser)
        {
            _requestParser = requestParser;
            SupportedMediaTypes.Clear();
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            using (var reader = new StreamReader(context.HttpContext.Request.Body))
            {
                var json = reader.ReadToEnd();
                var request = _requestParser.ParseRequest(json);
                return InputFormatterResult.SuccessAsync(request);
            }
        }
    }
}