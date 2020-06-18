using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using topcoderattempt1.Data;
using topcoderattempt1.Dtos;
using topcoderattempt1.Models;

namespace topcoderattempt1.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepo _repository;

        public UserController(IUserRepo repo, IMapper map)
        {
            _mapper = map;
            _repository = repo;
        }


        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var items = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(items));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var item = _repository.GetUserById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserReadDto>(item));
        }







    }
}
