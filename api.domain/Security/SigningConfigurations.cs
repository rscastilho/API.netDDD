using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace api.domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigingCredentials { get; set; }


        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048)){
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigingCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }

    }
}