using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomPolicyProvider
{
    internal class LoggedInRequired : AuthorizeAttribute
    {
        const string POLICE_NAME = "LoggedIn";
        public LoggedInRequired(bool req)
        {
            LoginRequired = req;
        }
        public LoggedInRequired()
        {
            LoginRequired = true;
        }
        public bool? LoginRequired
        {
            get
            {
                if (bool.TryParse(Policy.Substring(POLICE_NAME.Length), out var Login))
                {
                    return Login;
                }
                return default(bool);
            }
            set
            {
                Policy = $"{POLICE_NAME}{value.ToString()}";
            }
        }
    }
}
