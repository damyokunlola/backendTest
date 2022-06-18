using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Resources
{
    public class Response
    {
            public bool Status { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public object ResponseData { get; set; }

        
    }
}
