using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using topcoderattempt1.Dtos;
using topcoderattempt1.Profiles;

namespace topcoderattempt1.Backend.Authorization.ResourceBased
{
    public class AdminPermissionsHandler : AuthorizationHandler<OperationAuthorizationRequirement, int>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, int resourceRequestedLocation)
        {
            if(requirement.Name == Operations.ReadEdit.Name)
            {
                var userLocations = context.User.Claims?.FirstOrDefault(x => x.Type == "locationIds")?.Value;
                var userPermission = context.User.Claims?.FirstOrDefault(x => x.Type == "permissions")?.Value;
                List<int> locationIds = JsonConvert.DeserializeObject<List<int>>(userLocations);
                var permissions = JsonConvert.DeserializeObject<List<UserPermissionReadDto>>(userPermission);
                
                if (!locationIds.Contains(resourceRequestedLocation))
                {
                    context.Fail();
                    return Task.CompletedTask;
                } else
                {
                    var permissionAtLocation = permissions.FirstOrDefault(x => x.locationId == resourceRequestedLocation);
                    if(permissionAtLocation?.HasAdminEdit == true && permissionAtLocation?.HasAdminRead == true)
                    {
                        context.Succeed(requirement);

                        return Task.CompletedTask;

                    }
                }
            }
            return Task.CompletedTask;

        }

    }

    public static class Operations
    {
        public static OperationAuthorizationRequirement ReadEdit =
            new OperationAuthorizationRequirement { Name = nameof(ReadEdit) };
    }
}
