using Newtonsoft.Json;

namespace CurrencyConverter.Models
{
    internal class ValutesBuilder : AValutesBuilder
    {
        private readonly Data data = new Data();
        private RepositoryValute repositoryValute;
        private string json;

        public override void Convert()
        {
            repositoryValute = JsonConvert.DeserializeObject<RepositoryValute>(json);
        }

        public override void GetData()
        {
            json = data.GetAsString("https://www.cbr-xml-daily.ru/daily_json.js");
        }

        public override RepositoryValute GetValutes()
        {
            return repositoryValute;
        }
    }
}
