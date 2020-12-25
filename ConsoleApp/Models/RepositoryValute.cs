using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    internal class RepositoryValute
    {
        private AValutesBuilder builder;

        [JsonProperty("valute")]
        private readonly Dictionary<string, Valute> valutes = new Dictionary<string, Valute>();

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

        public RepositoryValute(AValutesBuilder builder)
        {
            this.builder = builder;
        }

        public Dictionary<string, Valute> getValutes()
        {
            builder.GetData();
            builder.Convert();
            return builder.GetValutes().valutes;
        }
    }
}
