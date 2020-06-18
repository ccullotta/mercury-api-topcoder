using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Tasks;
using topcoderattempt1.Backend;
using topcoderattempt1.Controllers;
using topcoderattempt1.Dtos;
using topcoderattempt1.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace topcoderattempt1.Data
{
    public class LocationsSqlRepo : ILocationRepo
    {
        private MercuryContext _context;
        private IMapper _mapper;

        public LocationsSqlRepo(MercuryContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }
        public async Task<string> GetLocationsAsync(ClaimsPrincipal user)
        {
            int userid;
            if(!int.TryParse(user.Claims.FirstOrDefault(x => x.Type == "ID").Value, out userid))
            {
                return null;
            }
            var User = await _context.Users
                .Include(x=>x.UserLocations)
                .ThenInclude(y=>y.Location)
                .FirstOrDefaultAsync(x => x.UserID == userid);
            if(User != null)
            {
                var LocationNames = User.UserLocations.Select(x => new
                {
                    ID = x.Location.ID,
                    Name = x.Location.Name
                }).ToList();
                var jsonLocations = JsonSerializer.Serialize(LocationNames);
                return jsonLocations;

            } return null;





        }

        public async Task<UserProfileDto?> GetUserAccountAsync(int locationId, IEnumerable<Claim> claims)
        {
            var user_id = claims?.FirstOrDefault(x => x.Type == "ID");
            int id;
            if(!int.TryParse(user_id?.Value, out id)) { return null; }
            var user = await _context.Users
                .Include(x => x.UserKeyMappings)
                .ThenInclude(x => x.Keyholder)
                .Include(x => x.UserLocations)
                .FirstOrDefaultAsync(x => x.UserID == id);
            var keyholdemap = user?.UserKeyMappings?.FirstOrDefault(x => x.LocationId == locationId);
            if (keyholdemap == null) { return null; };
            var model = _mapper.Map<UserProfileDto>(user);
            model.locationId = locationId;
            var tookit = _mapper.Map<ToolkitInfoDto>(keyholdemap.Keyholder);
            model.toolkitInfo = tookit;
            return model;
        }

        public Task<AdminListByLocationDto> GetUserListByLocation(int locationId, GetAdminListParameters parameters)
        {
            var users = _context.UserLocationAssignments
                .Include(x => x.Status)
                .Include(x => x.UserModel)
                .ThenInclude(x => x.UserKeyMappings)
                .Include(x => x.UserPermission)
                .Where(x => x.LocationId == locationId);
            var count = users.CountAsync();
            var enumtype = typeof(statusCode);
            List<AdminListItem> userList = users.Select(x => new AdminListItem()
            {
                id = x.UserModel.UserID,
                name = x.UserModel.Name,
                email = x.UserModel.Email,
                state = Enum.GetName(enumtype, x.State),
                disabledReason = x.DisabledReason,
                status = new Dictionary<string, string>
                {
                    { "id", x.StatusId.ToString() },
                    {"name", x.Status.Name }
                },
                toolkitInfo = _mapper.Map<ToolkitInfoDto>(x.UserModel.UserKeyMappings.FirstOrDefault(x => x.LocationId == locationId)),
                permissions = _mapper.Map<UserPermissionCompactDto>(x.UserPermission),
                recentActivity = _mapper.Map<UserActivityCompactDto>(x.UserModel.UserActivities.FirstOrDefault(x=>x.LocationId == locationId)),
            }).ToList();
            var result = new AdminListByLocationDto()
            {
                totalItems = count.Result,
                items = userList,
            };
            return Task.FromResult(result);
        }

        public async Task<UserProfileDto?> UpdateUserAccountAsync(
            int locationId, IEnumerable<Claim> claims, UpdateNameEmailDto update)
        {
            var user_id = claims?.FirstOrDefault(x => x.Type == "ID");
            int id;
            if (!int.TryParse(user_id?.Value, out id)) { return null; }
            var user = await _context.Users
                .Include(x => x.UserKeyMappings)
                .ThenInclude(x => x.Keyholder)
                .Include(x=>x.ChangeEmailRequests)
                .Include(x => x.UserLocations)
                .FirstOrDefaultAsync(x => x.UserID == id);
            var keyholdemap = user?.UserKeyMappings?.FirstOrDefault(x => x.LocationId == locationId);
            if (keyholdemap == null) { return null; };
            if (update.name != null)
            {
                user.Name = update.name;
            }
            Task save;
            if(update.email != null)
            {
                var email = EmailOperations.sendVerificationEmail(
                    user.Name, update.email, user.VerificationToken, true);
                user.Email = update.email;
                user.VerificationToken = Authentication.generateEmailTokenHash();
                user.VerificationTokenExpiry = DateTime.UtcNow.AddDays(1);

                var changeRequest = new ChangeEmailRequest()
                {
                    User = user,
                    RequestedOn = DateTime.UtcNow,
                    Email = update.email,
                    VerificationToken = user.VerificationToken,
                    VerificationTokenExpiry = user.VerificationTokenExpiry,
                };
                await _context.EmailChangeRequests.AddAsync(changeRequest);
                _context.Users.Update(user);
                await email;
                save =  _context.SaveChangesAsync();
            } else
            {
                _context.Users.Update(user);
                save = _context.SaveChangesAsync();
            }

            var model = _mapper.Map<UserProfileDto>(user);
            model.locationId = locationId;
            var tookit = _mapper.Map<ToolkitInfoDto>(keyholdemap.Keyholder);
            model.toolkitInfo = tookit;
            await save;
            return model;

        }
    }
}
