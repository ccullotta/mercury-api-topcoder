using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomPolicyProvider
{
    internal class LoggedInRequirment : IAuthorizationRequirement
    {
        public bool? IsLoggedIn { get; private set; }

        public LoggedInRequirment(bool? loggedIn)
        {
            IsLoggedIn = loggedIn;
        }
    }
}
