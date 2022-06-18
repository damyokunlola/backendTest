using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Banks
    {
        [JsonPropertyName("bankName")]

        public string BankName { get; set; }
        [JsonPropertyName("bankCode")]
        public string BankCode { get; set; }
    }
}
