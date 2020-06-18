using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;
using topcoderattempt1.Data;
using topcoderattempt1.Dtos;
using topcoderattempt1.Profiles;

namespace CustomPolicyProvider
{
    internal class LoggedInAuthorizationHandler : AuthorizationHandler<LoggedInRequirment>
    {
        private IServiceProvider _serviceProvider;

        public LoggedInAuthorizationHandler(IServiceProvider services)
        {
            _serviceProvider = services;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LoggedInRequirment requirement)
        {

            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<MercuryContext>();
                var _mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                var loggedInClaim = context.User.FindFirst(c => c.Type == "isLoggedIn");
                var idclaim = (context.User.Claims.FirstOrDefault(x => x.Type == "ID"));
                var permissions = JsonConvert.DeserializeObject<List<UserPermissionReadDto>>(context.User.Claims?.FirstOrDefault(x => x.Type == "permissions")?.Value)?.ToList();
                var dbset = _context.UserLocationAssignments
                    .Include(x => x.UserPermission)
                    .Where(x => x.UserId == int.Parse(idclaim.Value));
                var DBpermissions = dbset.Select(x => x.UserPermission).OrderBy(x=>x.UserLocationID)?.ToList();
                if (permissions.Contains(null) || DBpermissions.Contains(null)) { context.Fail(); return Task.CompletedTask; } else
                {
                    permissions.OrderBy(x => x.locationId);
                }

                    for (int x = 0; x < DBpermissions.Count; x++)
                {
                    if (!DBpermissions.ElementAt(x).IsEqualToReadDto(permissions.ElementAtOrDefault(x))){
                        context.Fail();
                        return Task.CompletedTask;
                    }
                }
                   

                if (loggedInClaim != null && idclaim != null)
                {
                    string Id = idclaim.Value;
                    var loggedIn = Convert.ToBoolean(loggedInClaim.Value);
                    var expiration = context.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Iat).Value;
                    var expirationDate = DateTimeOffset.FromUnixTimeSeconds(int.Parse(expiration)).AddDays(1);
                    if ( new DateTimeOffset(DateTime.UtcNow) < expirationDate && loggedIn == (requirement.IsLoggedIn ?? true))
                    {
                        context.Succeed(requirement);
                    }
                }
                return Task.CompletedTask;
            }

        }
    }
}
