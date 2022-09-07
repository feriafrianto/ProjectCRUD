using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraderSys.Portfolios.Helpers
{
    public class ResponseHeaderBuilder
    {
        public static ResponseHeader Build(bool success, string message, int statusCode)
        {
            return new ResponseHeader
            {
                Success = success,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}