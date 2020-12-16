using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.WebUI
{
    public class AuthenticationConfig
    {
        public static SecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisoursupersecretkeysssssssh"));

    }
}
