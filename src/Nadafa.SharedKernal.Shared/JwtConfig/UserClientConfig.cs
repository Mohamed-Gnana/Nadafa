using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Shared.JwtConfig
{
    public class UserClientConfig
    {
        public string WebUrl { get; set; }
        public UserClientJwtConfig Jwt { get; set; }
    }

    public class UserClientJwtConfig
    {
        public string Issuer { get; set; }
        public int MaxFailedAccessAttempts { get; set; }
        public string Key { get; set; }
        public string Audience { get; set; }
        public int ExpiryDuration { get; set; }
    }
}
