using AutoMapper;
using CustomPolicyProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using topcoderattempt1.Backend.Authorization.ResourceBased;
using topcoderattempt1.Dtos;

namespace topcoderattempt1.Controllers
{
    [Route("location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ILocationRepo _repository;
        private readonly IMapper _mapper;

        public LocationController(ILocationRepo repo, IMapper mapper, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _repository = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [LoggedInRequired]
        public async Task<IActionResult> GetUserLocationsAsync()
        {
            var ret = await _repository.GetLocationsAsync(User);
            return Ok(ret);
        }
        [HttpGet]
        [Route("{locationId:int}/accounts/profile")]
        [LoggedInRequired]
        public async Task<IActionResult> GetUserProfile([FromRoute] int locationId)
        {
            var ret = await _repository.GetUserAccountAsync(locationId, User.Claims);
            if(ret == null)
            {
                return BadRequest();
            }
            return Ok(ret);
        }
        [HttpPatch]
        [Route("{locationId:int}/accounts/profile")]
        [LoggedInRequired]
        public async Task<IActionResult> UpdateUserProfile([FromRoute] int locationId, UpdateNameEmailDto update)
        {
            var ret = await _repository.UpdateUserAccountAsync(locationId, User.Claims, update);
            if (ret == null)
            {
                return BadRequest();
            }
            return Ok(ret);
        }

        [HttpGet]
        [Route("{locationId:int}/administrators")]
        [LoggedInRequired]
        public async Task<IActionResult> getAdminLocationInfo([FromRoute] int locationId, [FromQuery] GetAdminListParameters parameters)
        {
            if (!(await _authorizationService
                .AuthorizeAsync(User, locationId, Operations.ReadEdit)).Succeeded) 
            {
                return Forbid();
            }

            var list = await _repository.GetUserListByLocation(locationId, parameters);

            return Ok(list);
        }
    }
}
