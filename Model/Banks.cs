using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.Model
{
    //public class Banks
    //{
    //    [JsonPropertyName("bankName")]

    //    public string BankName { get; set; }
    //    [JsonPropertyName("bankCode")]
    //    public string BankCode { get; set; }
    //}


    public class Banks
    {
        public Result[] result { get; set; }

    }

    public class Result
    {
        public string bankName { get; set; }
        public string bankCode { get; set; }
    }
}