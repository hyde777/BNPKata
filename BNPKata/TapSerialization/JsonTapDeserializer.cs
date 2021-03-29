using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BNPKata
{
    public class JsonTapDeserializer : ITapDeserializer
    {
        private const string PROPERTY_NAME = "taps";

        public IEnumerable<Tap> Serialize(string rawPath)
        {
            var taps = JObject.Parse(File.ReadAllText(rawPath))[PROPERTY_NAME].Children().ToList();

            foreach (JToken tap in taps)
            {
                yield return tap.ToObject<Tap>();
            }
        }
    }
}