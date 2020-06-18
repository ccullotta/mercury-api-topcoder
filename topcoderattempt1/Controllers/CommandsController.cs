using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace topcoderattempt1.Controllers
{
    //[Route("api/[controller]")] will use controller name 
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository; //repository probably equivelent to _contect form previous project 
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository; // this is depency injected value 
            _mapper = mapper;

        }

        // Get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var items = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(items));
        }

        // Get api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        [Authorize]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var item = _repository.GetCommandById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(item));
            }

            return NotFound();
        }

        //returns command read dto because we are now going to view the created model
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto createDto)
        {
            var model = _mapper.Map<Command>(createDto);
            _repository.CreateCommand(model);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(model);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
            //return Ok(commandReadDto); REST requires 201 "created" tag and a URI where the new thing can be found

        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto updateDto)
        {
            var repoModel = _repository.GetCommandById(id);
            if (repoModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateDto, repoModel);

            _repository.UpdateCommand(repoModel);

            _repository.SaveChanges();

            return NoContent();
        }

        //pathc api.commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var repoModel = _repository.GetCommandById(id);
            if (repoModel == null)
            {
                return NotFound();
            }

            var patch = _mapper.Map<CommandUpdateDto>(repoModel); // make use of new profile here - specialized for jsonpatch
            patchDoc.ApplyTo(patch, ModelState);

            if (!TryValidateModel(patch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(patch, repoModel);
            _repository.UpdateCommand(repoModel);

            _repository.SaveChanges();

            return NoContent();

        }

        //
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var repoModel = _repository.GetCommandById(id);
            if (repoModel == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(repoModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [Route("auth")]
        public IActionResult Authenticate()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "some_id"),
                new Claim("name", "teta"),
                new Claim("at", "teta"),
                new Claim("locationIds", "teta"),
                new Claim("permissions", "teta"),
                new Claim("isLoggedIn", "teta"),
                new Claim("id", "teta"),
            };

            var secretbytest = Encoding.UTF8.GetBytes(Constants.SecretKey);
            var key = new SymmetricSecurityKey(secretbytest);
            var algorithm = SecurityAlgorithms.HmacSha256;
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Audiance,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { access_token = tokenJson });
        }
    }
}
