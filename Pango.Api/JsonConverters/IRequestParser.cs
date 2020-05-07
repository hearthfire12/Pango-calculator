using Pango.Api.Models;

namespace Pango.Api.JsonConverters
{
    public interface IRequestParser
    {
        Request ParseRequest(string json);
    }
}