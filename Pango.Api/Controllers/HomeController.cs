using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pango_Lib.Expressions.Contract;
using Pango.Api.JsonConverters;
using Pango.Api.Models;

namespace Pango.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly RequestParser _parser;

        public HomeController(RequestParser parser)
        {
            _parser = parser;
        }
        
        public Response Calculate([FromBody] Request request)
        {
            var result = request.Expression.Calculate();

            if (request.Client == ClientType.Mobile)
            {
                return new MobileResponse(result);
            }

            return new DesktopResponse(result);
        }

        public IEnumerable<OperationType> OperationTypes()
        {
            return Enum.GetValues(typeof(OperationType)).Cast<OperationType>();
        }
    }
}