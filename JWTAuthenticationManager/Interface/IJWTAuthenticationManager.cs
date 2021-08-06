using System;
using System.Collections.Generic;
using System.Text;

namespace JWTAuthenticationManager.Interface
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
