using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomPolicyProvider
{
    internal class LoginRequiredPolicyProvider : IAuthorizationPolicyProvider
    {
        const string POLICE_NAME = "LoggedIn";
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public LoginRequiredPolicyProvider(IOptions<AuthorizationOptions> options) 
        {
            //save default provider options if needed
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return FallbackPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            return FallbackPolicyProvider.GetFallbackPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if(policyName.StartsWith(POLICE_NAME, StringComparison.OrdinalIgnoreCase) &&
                bool.TryParse(policyName.Substring(POLICE_NAME.Length), out var loggedInReq))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new LoggedInRequirment(loggedInReq));
                return Task.FromResult(policy.Build());
            }
            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
