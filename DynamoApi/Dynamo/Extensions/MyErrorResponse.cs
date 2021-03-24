using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamo.Extensions
{
    public class MyErrorResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int Code { get; set; }
        public MyErrorResponse(Exception ex, int code)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            Code = code;
            StackTrace = ex.ToString();
        }


    }
}
