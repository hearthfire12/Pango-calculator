namespace Pango.Api.Models
{
    public abstract class Response
    {
        protected Response(decimal value)
        {
            Value = value;
        }

        private decimal Value { get; }
    }
}