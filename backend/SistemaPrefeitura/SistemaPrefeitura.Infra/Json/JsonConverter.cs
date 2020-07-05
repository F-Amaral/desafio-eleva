using Newtonsoft.Json;
using SistemaPrefeitura.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Infra.Json
{
    public class JsonConverter : IJsonConverter
    {
        public T Deserialize<T>(string serialized)
        {
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public string Serialize(object t)
        {
            return JsonConvert.SerializeObject(t);
        }
    }
}
