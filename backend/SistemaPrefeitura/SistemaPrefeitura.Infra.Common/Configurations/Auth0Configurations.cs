using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Infra.Common.Configurations
{
    public class Auth0Configurations
    {
        public string Authority { get; set; }
        public string Audience { get; set; }
        public string ClientId { get; set; }
    }
}
