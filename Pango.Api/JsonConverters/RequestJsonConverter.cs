using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pango.Api.Models;

namespace Pango.Api.JsonConverters
{
    public class RequestJsonConverter : JsonConverter<Request>
    {
        public override Request Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return null;
        }

        public override void Write(Utf8JsonWriter writer, Request value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}