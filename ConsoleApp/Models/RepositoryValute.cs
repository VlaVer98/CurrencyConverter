using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    internal class RepositoryValute
    {
        [JsonProperty("valute")]
        public readonly Dictionary<string, Valute> valutes = new Dictionary<string, Valute>();

        internal class Valute
        {
            public string ID { get; set; }
            public string NumCode { get; set; }
            public string CharCode { get; set; }
            public decimal Nominal { get; set; }
            public string Name { get; set; }
            public decimal Value { get; set; }
            public decimal Previous { get; set; }
        }
    }
}
