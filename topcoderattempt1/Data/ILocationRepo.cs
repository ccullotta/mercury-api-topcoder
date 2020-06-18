using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using topcoderattempt1.Dtos;

namespace topcoderattempt1.Controllers
{
    public interface ILocationRepo
    {
        Task<string> GetLocationsAsync(ClaimsPrincipal user);
        Task<UserProfileDto?> GetUserAccountAsync(int locationId, IEnumerable<Claim> claims);
        Task<UserProfileDto?> UpdateUserAccountAsync(int locationId, IEnumerable<Claim> claims, UpdateNameEmailDto update);
        Task<AdminListByLocationDto> GetUserListByLocation(int locationId, GetAdminListParameters parameters);
    }
}