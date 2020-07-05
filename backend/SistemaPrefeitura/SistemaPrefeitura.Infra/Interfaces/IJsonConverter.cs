using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Infra.Interfaces
{
    public interface IJsonConverter
    {
        string Serialize(object t);
        T Deserialize<T>(string serialized);

    }
}
