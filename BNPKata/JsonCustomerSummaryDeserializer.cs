using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BNPKata
{
    public class JsonCustomerSummaryDeserializer : ICustomerSummaryDeserializer
    {
        public string Serialize(Journeys journeys)
        {
            return JsonConvert.SerializeObject(journeys,
                Formatting.Indented, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }
}