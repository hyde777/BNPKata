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
    public class MyJsonSerializer : ISerializer
    {
        public IEnumerable<Tap> Serialize(string rawPath)
        {
            var raw = JObject.Parse(File.ReadAllText(rawPath))["taps"].Children().ToList();

            foreach (JToken tap in raw)
            {
                yield return tap.ToObject<Tap>();
            }
        }
    }
}